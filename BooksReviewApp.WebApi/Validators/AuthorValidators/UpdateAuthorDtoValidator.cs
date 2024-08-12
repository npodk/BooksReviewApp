using BooksReviewApp.WebApi.Dtos.Author;
using BooksReviewApp.WebApi.Services;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class UpdateAuthorDtoValidator : BaseValidator<UpdateAuthorDto>
    {
        public UpdateAuthorDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            Include(new CreateAuthorDtoValidator(localizationService));
        }
    }
}
