using System;
using FluentValidation;
using Phones.Domain.DTOs.Brands;

namespace Phones.Host.Validators.Phones
{
    public class CreatePhoneDtoValidator : AbstractValidator<CreatePhoneDto>
    {
        public CreatePhoneDtoValidator()
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