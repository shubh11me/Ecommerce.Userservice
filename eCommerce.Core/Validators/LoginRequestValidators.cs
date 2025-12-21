using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidators:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidators()
        {
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.password)
            .PasswordRules();
        }
    }
}
