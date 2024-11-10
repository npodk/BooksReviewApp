using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static Identity.WebApi.Constants;

namespace Identity.WebApi.Extensions
{
    public static class AccountValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyUsernameRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(AccountValidation.MaxUsernameLength)
                .WithMessage(localizationService.GetValidationMessage("UsernameMaxLength", AccountValidation.MaxUsernameLength));
        }

        public static IRuleBuilder<T, string> ApplyPasswordRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MinimumLength(AccountValidation.MinPasswordLength)
                .WithMessage(localizationService.GetValidationMessage("PasswordMinLength", AccountValidation.MinPasswordLength))
                .MaximumLength(AccountValidation.MaxPasswordLength)
                .WithMessage(localizationService.GetValidationMessage("PasswordMaxLength", AccountValidation.MaxPasswordLength))
                .Matches(AccountValidation.PasswordPattern)
                .WithMessage(localizationService.GetValidationMessage("PasswordPattern"));
        }

        public static IRuleBuilder<T, string> ApplyEmailRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(AccountValidation.MaxEmailLength)
                .WithMessage(localizationService.GetValidationMessage("EmailMaxLength", AccountValidation.MaxEmailLength))
                .EmailAddress()
                .WithMessage(localizationService.GetValidationMessage("InvalidEmailFormat"));
        }
    }
}
