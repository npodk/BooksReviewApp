using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Book;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.BookValidators
{
    public class BaseBookDtoValidator<T> : BaseValidator<T> where T : BaseBookDto
    {
        public BaseBookDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("TitleIsRequired"))
                .ApplyTitleRules(localizationService);

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PublisherIsRequired"))
                .ApplyPublisherRules(localizationService);

            RuleFor(x => x.PublishingYear)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PublishingYearIsRequired"))
                .ApplyPublishingYearRules(localizationService);

            RuleFor(x => x.WritingYear)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("WritingYearIsRequired"))
                .ApplyWritingYearRules(localizationService);

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("ISBNIsRequired"))
                .ApplyISBNRules(localizationService);

            RuleFor(x => x.Description)
                .ApplyDescriptionRules(localizationService);

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("AuthorIdIsRequired"));
        }   
    }
}
