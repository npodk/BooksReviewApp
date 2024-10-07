using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Genre;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.GenreValidators
{
    public class UpdateGenreDtoValidator : BaseValidator<UpdateGenreDto>
    {
        public UpdateGenreDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            Include(new CreateGenreDtoValidator(localizationService));
        }
    }
}
