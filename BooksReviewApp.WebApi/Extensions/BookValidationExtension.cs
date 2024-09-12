using BooksReviewApp.Core.Services.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class BookValidationExtension
    {
        public static IRuleBuilder<T, string> ApplyTitleRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(BookValidation.MaxTitleLength)
                .WithMessage(localizationService.GetValidationMessage("TitleMaxLength", BookValidation.MaxTitleLength));
        }

        public static IRuleBuilder<T, string> ApplyPublisherRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(BookValidation.MaxPublisherLength)
                .WithMessage(localizationService.GetValidationMessage("PublisherMaxLength", BookValidation.MaxPublisherLength));
        }

        public static IRuleBuilder<T, string> ApplyISBNRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .Matches(BookValidation.ISBNPattern)
                .WithMessage(localizationService.GetValidationMessage("ISBNInvalidFormat"));
        }

        public static IRuleBuilder<T, string> ApplyDescriptionRules<T>(this IRuleBuilder<T, string?> ruleBuilder, ILocalizationService localizationService)
        {
            return ruleBuilder
                .MaximumLength(BookValidation.MaxDescriptionLength)
                .WithMessage(localizationService.GetValidationMessage("DescriptionMaxLength", BookValidation.MaxDescriptionLength));
        }

        public static IRuleBuilder<T, int> ApplyPublishingYearRules<T>(this IRuleBuilder<T, int> ruleBuilder, ILocalizationService localizationService)
        {
            int currentYear = DateTime.Now.Year;
            return ruleBuilder
                .InclusiveBetween(BookValidation.MinPublishingYear, currentYear)
                .WithMessage(localizationService.GetValidationMessage("PublishingYearOutOfRange", BookValidation.MinPublishingYear, currentYear));
        }

        public static IRuleBuilder<T, int> ApplyWritingYearRules<T>(this IRuleBuilder<T, int> ruleBuilder, ILocalizationService localizationService)
        {
            int currentYear = DateTime.Now.Year;
            return ruleBuilder
                .InclusiveBetween(BookValidation.MinWritingYear, currentYear)
                .WithMessage(localizationService.GetValidationMessage("WritingYearOutOfRange", BookValidation.MinWritingYear, currentYear));
        }
    }
}
