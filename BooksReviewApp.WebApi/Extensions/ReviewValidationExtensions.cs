using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class ReviewValidationExtensions
    {
        public static IRuleBuilder<T, string> ApplyReviewTextRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(ReviewValidation.MaxTextLength)
                .WithMessage(localizationService.GetValidationMessage("ReviewTextMaxLength", ReviewValidation.MaxTextLength));
        }

        public static IRuleBuilder<T, int> ApplyReviewRatingRules<T>(this IRuleBuilder<T, int> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .InclusiveBetween(ReviewValidation.MinRating, ReviewValidation.MaxRating)
                .WithMessage(localizationService.GetValidationMessage("ReviewRatingOutOfRange", ReviewValidation.MinRating, ReviewValidation.MaxRating));
        }
    }
}
