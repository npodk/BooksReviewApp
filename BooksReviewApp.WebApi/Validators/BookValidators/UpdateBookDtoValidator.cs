using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Book;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.BookValidators
{
    public class UpdateBookDtoValidator : BaseValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            Include(new CreateBookDtoValidator(localizationService));
        }
    }
}
