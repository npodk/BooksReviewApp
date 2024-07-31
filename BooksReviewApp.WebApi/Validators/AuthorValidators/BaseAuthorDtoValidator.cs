using BooksReviewApp.WebApi.Dtos.Author;
using BooksReviewApp.WebApi.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class BaseAuthorDtoValidator<T> : BaseValidator<T> where T : BaseAuthorDto
    {
        public BaseAuthorDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("NameIsRequired"))
                .MaximumLength(AuthorValidation.MaxNameLength)
                .WithMessage(localizationService.GetValidationMessage("NameMaxLength", AuthorValidation.MaxNameLength));

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("SurnameIsRequired"))
                .MaximumLength(AuthorValidation.MaxSurnameLength)
                .WithMessage(localizationService.GetValidationMessage("SurnameMaxLength", AuthorValidation.MaxSurnameLength));

            RuleFor(x => x.Biography)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("BiographyIsRequired"))
                .MaximumLength(AuthorValidation.MaxBiographyLength)
                .WithMessage(localizationService.GetValidationMessage("BiographyMaxLength", AuthorValidation.MaxBiographyLength));
        }
    }
}
