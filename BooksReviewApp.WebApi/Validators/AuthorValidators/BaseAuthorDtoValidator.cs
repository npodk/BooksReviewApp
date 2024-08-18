using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Author;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class BaseAuthorDtoValidator<T> : BaseValidator<T> where T : BaseAuthorDto
    {
        public BaseAuthorDtoValidator(ILocalizationService localizationService)
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
