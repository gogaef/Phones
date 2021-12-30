using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phones.Domain.DTOs.Brands;
using Phones.Domain.Entities;

namespace Phones.Domain.Abstractions.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> Get();

        Task<Brand> Create(CreateBrandDto brandDto);

        Task Delete(Guid id);
    }
}