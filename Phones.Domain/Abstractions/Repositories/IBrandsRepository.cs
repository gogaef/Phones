using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phones.Domain.Entities;

namespace Phones.Domain.Abstractions.Repositories
{
    public interface IBrandsRepository
    {
        Task<Brand> Create(Brand brand);
        
        Task<IEnumerable<Brand>> Get();
        
        Task Delete(Brand brand);
        
        Task<Brand> Get(string name);
        
        Task<Brand> Get(Guid id);
    }
}