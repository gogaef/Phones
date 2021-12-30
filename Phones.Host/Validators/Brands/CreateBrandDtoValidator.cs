using FluentValidation;
using Phones.Domain.DTOs.Brands;

namespace Phones.Host.Validators.Brands
{
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(256);
        }
    }
}