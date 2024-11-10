using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Permission;

namespace Identity.WebApi.Validators.PermissionValidators
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
