using FluentValidation;
using Unittest.Api.Models;

namespace Unittest.Api.Validators
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreateDTO>
    {
        public CustomerCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("İsim null olamaz")
                .NotEmpty().WithMessage("İsim boş olamaz")
                .MinimumLength(3).WithMessage("İsim minimum 3 karakter olmalıdır");
            
            RuleFor(x => x.Surname)
                .NotNull().WithMessage("Soyisim null olamaz")
                .NotEmpty().WithMessage("Soyisim boş olamaz")
                .MinimumLength(3).WithMessage("Soyisim minimum 3 karakter olmalıdır");

            When(x => x.Limit.HasValue, () =>
            {
                RuleFor(y=> y.Limit.Value)
                    .GreaterThanOrEqualTo(1).WithMessage("Limit minimum 1 olmalıdır");
            });
        }
    }
}