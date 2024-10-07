using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Genre;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.GenreValidators
{
    public class CreateGenreDtoValidator : BaseValidator<CreateGenreDto>
    {
        public CreateGenreDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("GenreNameIsRequired"))
                .ApplyGenreNameRules(localizationService);

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("GenreDescriptionIsRequired"))
                .ApplyGenreDescriptionRules(localizationService);
        }
    }

}
