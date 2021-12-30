using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phones.Domain.Entities;

namespace Phones.Domain.Abstractions.Repositories
{
    public interface IPhonesRepository
    {
        Task<IEnumerable<Phone>> Get();

        Task<Phone> Create(Phone phone);

        Task Delete(Phone phone);

        Task<Phone> Update(Phone phone);

        Task<Phone> Get(Guid id);
    }
}