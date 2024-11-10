using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Role;

namespace Identity.WebApi.Validators.RoleValidators
{
    public class AssignRoleDtoValidator : BaseValidator<AssignRoleDto>
    {
        public AssignRoleDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("UserIdIsRequired"));

            Include(new RoleDtoValidator(localizationService));
        }
    }
}
