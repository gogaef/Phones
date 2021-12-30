using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phones.Domain.Abstractions.Repositories;
using Phones.Domain.Entities;

namespace Phones.Infrastrructure.Repositories
{
    public class PhonesRepository : IPhonesRepository
    {
        private readonly ApplicationDbContext _context;


        public PhonesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Phone>> Get()
        {
            return await _context.Phones.ToListAsync();
        }

        public async Task<Phone> Create(Phone phone)
        {
            var newPhone =  _context.Phones.Add(phone);
            await _context.SaveChangesAsync();
            return newPhone.Entity;
        }

        public async Task Delete(Phone phone)
        {
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
        }

        public async Task<Phone> Update(Phone phone)
        {
            var result = _context.Phones.Update(phone);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<Phone> Get(Guid id)
        {
            return await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}