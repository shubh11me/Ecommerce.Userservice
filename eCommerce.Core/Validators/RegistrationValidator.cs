using eCommerce.Core.DTO;
using FluentValidation;
namespace eCommerce.Core.Validators
{
    public class RegistrationValidator:AbstractValidator<RegisterRequest>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password)
                .PasswordRules();
            RuleFor(x => x.PersonName)
                .NotEmpty().WithMessage("Person Name is required")
                .MinimumLength(2).WithMessage("Person Name must be at least 2 characters long")
                .MaximumLength(50).WithMessage("Person Name must not exceed 50 characters");
            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Gender must be a valid value");
        }
    }
}
