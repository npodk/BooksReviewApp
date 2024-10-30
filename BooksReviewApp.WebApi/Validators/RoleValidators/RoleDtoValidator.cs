using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Role;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.RoleValidators
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
