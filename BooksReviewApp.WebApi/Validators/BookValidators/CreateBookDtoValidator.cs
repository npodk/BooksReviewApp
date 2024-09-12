using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Book;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.BookValidators
{
    public class CreateBookDtoValidator : BaseBookDtoValidator<CreateBookDto>
    {
        public CreateBookDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
            RuleFor(x => x.GenreIds)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("GenreIdsIsRequired"))
                .Must(ids => ids.Length > 0).WithMessage(localizationService.GetValidationMessage("AtLeastOneGenreRequired"));
        }
    }
}
