using FluentValidation;
using Phones.Domain.DTOs.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phones.Host.Validators.Brands
{
    public class DeleteBrandDtoValidator : AbstractValidator<BrandDto>
    {
        public DeleteBrandDtoValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x != Guid.Empty);
        }
    }
}
