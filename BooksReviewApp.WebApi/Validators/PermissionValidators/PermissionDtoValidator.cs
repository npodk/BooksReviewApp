using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Permission;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.PermissionValidators
{
    public class PermissionDtoValidator : BaseValidator<BasePermissionDto>
    {
        public PermissionDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetValidationMessage("PermissionNameIsRequired"))
                .MaximumLength(256)
                .WithMessage(localizationService.GetValidationMessage("PermissionNameTooLong"));
        }
    }
}
