using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class AuthorValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyNameRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(AuthorValidation.MaxNameLength)
                .WithMessage(localizationService.GetValidationMessage("NameMaxLength", AuthorValidation.MaxNameLength));
        }

        public static IRuleBuilder<T, string> ApplySurnameRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(AuthorValidation.MaxSurnameLength)
                .WithMessage(localizationService.GetValidationMessage("SurnameMaxLength", AuthorValidation.MaxSurnameLength));
        }

        public static IRuleBuilder<T, string> ApplyBiographyRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(AuthorValidation.MaxBiographyLength)
                .WithMessage(localizationService.GetValidationMessage("BiographyMaxLength", AuthorValidation.MaxBiographyLength));
        }
    }
}
