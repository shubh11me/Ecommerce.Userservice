using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string?> PasswordRules<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().WithMessage("Password is required.")
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain an uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain a number.")
                .Matches("[^A-Za-z0-9]").WithMessage("Password must contain a special character.");
        }
    }
}
