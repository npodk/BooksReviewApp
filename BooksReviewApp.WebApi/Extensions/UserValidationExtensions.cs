using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class UserValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyUsernameRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(UserValidation.MaxUsernameLength)
                .WithMessage(localizationService.GetValidationMessage("UsernameMaxLength", UserValidation.MaxUsernameLength));
        }

        public static IRuleBuilder<T, string> ApplyEmailRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(UserValidation.MaxEmailLength)
                .WithMessage(localizationService.GetValidationMessage("EmailMaxLength", UserValidation.MaxEmailLength))
                .EmailAddress()
                .WithMessage(localizationService.GetValidationMessage("InvalidEmailFormat"));
        }

        public static IRuleBuilder<T, string> ApplyPasswordRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MinimumLength(UserValidation.MinPasswordLength)
                .WithMessage(localizationService.GetValidationMessage("PasswordMinLength", UserValidation.MinPasswordLength))
                .MaximumLength(UserValidation.MaxPasswordLength)
                .WithMessage(localizationService.GetValidationMessage("PasswordMaxLength", UserValidation.MaxPasswordLength))
                .Matches(UserValidation.PasswordPattern)
                .WithMessage(localizationService.GetValidationMessage("PasswordPattern"));
        }
    }
}
