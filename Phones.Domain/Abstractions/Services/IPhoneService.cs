using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phones.Domain.DTOs.Brands;
using Phones.Domain.Entities;

namespace Phones.Domain.Abstractions.Services
{
    public interface IPhoneService
    {
        Task<Phone> Create(CreatePhoneDto dto);

        Task<Phone> Update(Guid id, UpdatePhoneDto dto);

        Task<IEnumerable<Phone>> Get();

        Task Delete(Guid id);
    }
}