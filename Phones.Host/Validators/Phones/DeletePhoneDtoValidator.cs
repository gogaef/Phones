using FluentValidation;
using Phones.Domain.DTOs.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phones.Host.Validators.Phones
{
    public class DeletePhoneDtoValidator : AbstractValidator<PhoneDto>
    {
        public DeletePhoneDtoValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty);
        }
    }
}
