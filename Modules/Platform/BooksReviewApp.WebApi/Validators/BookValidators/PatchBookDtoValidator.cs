using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.WebApi.Dtos.Book;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Validators.BookValidators
{
    public class PatchBookDtoValidator : BaseValidator<PatchBookDto>
    {
        public PatchBookDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(dto => dto.Title)
                .NotNull().When(dto => dto.Title != null)
                .ApplyTitleRules(localizationService);

            RuleFor(dto => dto.Publisher)
                .NotNull().When(dto => dto.Publisher != null)
                .ApplyPublisherRules(localizationService);

            RuleFor(dto => dto.PublishingYear)
                .NotNull().WithMessage(localizationService.GetValidationMessage("PublishingYearIsRequired"))
                .When(dto => dto.PublishingYear.HasValue)
                .InclusiveBetween(BookValidation.MinPublishingYear, DateTime.Now.Year)
                .WithMessage(localizationService.GetValidationMessage("PublishingYearOutOfRange", BookValidation.MinPublishingYear, DateTime.Now.Year));

            RuleFor(dto => dto.WritingYear)
                .NotNull().WithMessage(localizationService.GetValidationMessage("WritingYearIsRequired"))
                .When(dto => dto.WritingYear.HasValue)
                .InclusiveBetween(BookValidation.MinWritingYear, DateTime.Now.Year)
                .WithMessage(localizationService.GetValidationMessage("WritingYearOutOfRange", BookValidation.MinWritingYear, DateTime.Now.Year));

            RuleFor(dto => dto.ISBN)
                .NotNull().When(dto => dto.ISBN != null)
                .ApplyISBNRules(localizationService);

            RuleFor(dto => dto.Description)
                .ApplyDescriptionRules(localizationService);

            RuleFor(dto => dto.AuthorId)
                .NotEmpty().When(dto => dto.AuthorId.HasValue)
                .WithMessage(localizationService.GetValidationMessage("AuthorIdIsRequired"));
        }
    }
}
