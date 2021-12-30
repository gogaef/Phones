using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phones.Domain.Abstractions.Repositories;
using Phones.Domain.Entities;

namespace Phones.Infrastrructure.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly ApplicationDbContext _context;
        
        public BrandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> Create(Brand brand)
        {
            var newBrand = await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return newBrand.Entity;
        }

        public async Task<IEnumerable<Brand>> Get()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Brand> Get(string name)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Name == name);
        }
        
        public async Task<Brand> Get(Guid id)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}