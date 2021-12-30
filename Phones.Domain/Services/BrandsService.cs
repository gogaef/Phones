using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phones.Domain.Abstractions.Repositories;
using Phones.Domain.Abstractions.Services;
using Phones.Domain.DTOs.Brands;
using Phones.Domain.Entities;

namespace Phones.Domain.Services
{
    public class BrandsService : IBrandService
    {
        private readonly IBrandsRepository _brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        public async Task<IEnumerable<Brand>> Get()
        {
            return await _brandsRepository.Get();
        }

        public async Task<Brand> Create(CreateBrandDto brandDto)
        {
            var existingBrand = await _brandsRepository.Get(brandDto.Name);
            
            if (existingBrand is not null)
            {
                // Exception return 
            }
            
            var brand = new Brand();
            brand.Name = brandDto.Name;
            brand.Id = Guid.NewGuid();
            await _brandsRepository.Create(brand);
            
            return brand;
        }

        public async Task Delete(Guid id)
        {
            var brand = await _brandsRepository.Get(id);
            
            if (brand is null)
            {
                // Exception return 
            }
            
            await _brandsRepository.Delete(brand);
        }
    }
}