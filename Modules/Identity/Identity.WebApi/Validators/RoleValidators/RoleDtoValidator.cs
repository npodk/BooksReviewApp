using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Role;

namespace Identity.WebApi.Validators.RoleValidators
{
    public class RoleDtoValidator : BaseValidator<RoleDto>
    {
        public RoleDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage(localizationService.GetValidationMessage("RoleNameIsRequired"))
                .MaximumLength(50)
                .WithMessage(localizationService.GetValidationMessage("RoleNameTooLong"));
        }
    }
}
