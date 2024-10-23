using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class AccountValidationExtensions
    {
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
