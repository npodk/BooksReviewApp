using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.WebApi.Dtos.Genre;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.GenreValidators
{
    public class PatchGenreDtoValidator : BaseValidator<PatchGenreDto>
    {
        public PatchGenreDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(dto => dto.Name)
                .NotNull().When(dto => dto.Name != null)
                .ApplyGenreNameRules(localizationService);

            RuleFor(dto => dto.Description)
                .NotNull().When(dto => dto.Description != null)
                .ApplyGenreDescriptionRules(localizationService);
        }
    }
}
