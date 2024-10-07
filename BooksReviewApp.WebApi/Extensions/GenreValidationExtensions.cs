using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class GenreValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyGenreNameRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(GenreValidation.MaxNameLength)
                .WithMessage(localizationService.GetValidationMessage("GenreNameMaxLength", GenreValidation.MaxNameLength));
        }

        public static IRuleBuilder<T, string> ApplyGenreDescriptionRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(GenreValidation.MaxDescriptionLength)
                .WithMessage(localizationService.GetValidationMessage("GenreDescriptionMaxLength", GenreValidation.MaxDescriptionLength));
        }
    }
}
