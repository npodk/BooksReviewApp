using FluentValidation;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class UserValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyUsernameRules<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .MaximumLength(UserValidation.MaxUsernameLength).WithMessage($"Username must not exceed {UserValidation.MaxUsernameLength} characters.");
        }

        public static IRuleBuilder<T, string> ApplyEmailRules<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .MaximumLength(UserValidation.MaxEmailLength).WithMessage($"Email must not exceed {UserValidation.MaxEmailLength} characters.")
                .EmailAddress().WithMessage("Invalid email format.");
        }

        public static IRuleBuilder<T, string> ApplyPasswordRules<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .MinimumLength(UserValidation.MinPasswordLength).WithMessage($"Password must be at least {UserValidation.MinPasswordLength} characters long.")
                .MaximumLength(UserValidation.MaxPasswordLength).WithMessage($"Password must not exceed {UserValidation.MaxPasswordLength} characters.")
                .Matches(UserValidation.PasswordPattern).WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.");
        }
    }
}
