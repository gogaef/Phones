using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phones.Domain.Abstractions.Repositories;
using Phones.Domain.Abstractions.Services;
using Phones.Domain.DTOs.Brands;
using Phones.Domain.Entities;

namespace Phones.Domain.Services
{
    public class PhonesService : IPhoneService
    {
        private readonly IPhonesRepository _phonesRepository;
        private readonly IBrandsRepository _brandsRepository;

        public PhonesService(IPhonesRepository phonesRepository, IBrandsRepository brandsRepository)
        {
            _phonesRepository = phonesRepository;
            _brandsRepository = brandsRepository;
        }

        public async Task<Phone> Create(CreatePhoneDto dto)
        {
            var brand = await _brandsRepository.Get(dto.BrandId);
            
            if (brand is null)
            {
                // Exception return 
            }
            
            var phone = new Phone();
            phone.Id = Guid.NewGuid();
            phone.Brand = brand;
            phone.Color = dto.Color;
            phone.Model = dto.Model;
            phone.Price = dto.Price;
            phone.OSType = dto.OSType;
            phone.Type = dto.Type;

            await _phonesRepository.Create(phone);
            return phone;
        }

        public async Task<Phone> Update(Guid id, UpdatePhoneDto dto)
        {
            var phone = await _phonesRepository.Get(id);
            
            if (phone is null)
            {
                // Exception return 
            }
            
            var brand = await _brandsRepository.Get(dto.BrandId);
            
            if (brand is null)
            {
                // Exception return 
            }

            phone.Brand = brand;
            phone.Color = dto.Color;
            phone.Model = dto.Model;
            phone.Price = dto.Price;
            phone.OSType = dto.OSType;
            phone.Type = dto.Type;

            await _phonesRepository.Update(phone);
            return phone;
        } 
        
        public async Task<IEnumerable<Phone>> Get()
        {
            return await _phonesRepository.Get();
        }
        
        public async Task Delete(Guid id)
        {
            var phone = await _phonesRepository.Get(id);
            
            if (phone is null)
            {
                // Exception return 
            }
            
            await _phonesRepository.Delete(phone);
        }
    }
}