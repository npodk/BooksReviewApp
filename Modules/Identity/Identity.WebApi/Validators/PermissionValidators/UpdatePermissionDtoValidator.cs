using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Permission;

namespace Identity.WebApi.Validators.PermissionValidators
{
    public class UpdatePermissionDtoValidator : BaseValidator<PermissionDto>
    {
        public UpdatePermissionDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty)
                .WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            Include(new PermissionDtoValidator(localizationService));
        }
    }
}
