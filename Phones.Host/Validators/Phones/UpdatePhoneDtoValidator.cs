using FluentValidation;
using Phones.Domain.DTOs.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phones.Host.Validators.Phones
{
    public class UpdatePhoneDtoValidator : AbstractValidator<UpdatePhoneDto>
    {
        public UpdatePhoneDtoValidator()
        {
            RuleFor(x => x.Model)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(x => x.BrandId)
                .Must(x => x != Guid.Empty);
            RuleFor(x => x.Color)
                .MaximumLength(256)
                .NotEmpty();
            RuleFor(x => x.Price)
                .GreaterThan(0);
        }
    }
}
