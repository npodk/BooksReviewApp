using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Role;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.RoleValidators
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
