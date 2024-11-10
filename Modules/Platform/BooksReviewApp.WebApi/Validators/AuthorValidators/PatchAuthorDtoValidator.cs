using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.WebApi.Dtos.Author;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.AuthorValidators
{
    public class PatchAuthorDtoValidator : BaseValidator<PatchAuthorDto>
    {
        public PatchAuthorDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(x => x.Name)
                .NotNull().When(dto => dto.Name != null)
                .ApplyNameRules(localizationService);

            RuleFor(x => x.Surname)
                .NotNull().When(dto => dto.Surname != null)
                .ApplySurnameRules(localizationService);

            RuleFor(x => x.Biography)
                .NotNull().When(dto => dto.Biography != null)
                .ApplyBiographyRules(localizationService);
        }
    }
}
