using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.WebApi.Dtos.Author;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class CreateBookDtoValidator : BaseValidator<CreateAuthorDto>
    {
        public CreateBookDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("NameIsRequired"))
                .ApplyNameRules(localizationService);

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("SurnameIsRequired"))
                .ApplySurnameRules(localizationService);

            RuleFor(x => x.Biography)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("BiographyIsRequired"))
                .ApplyBiographyRules(localizationService);
        }
    }
}
