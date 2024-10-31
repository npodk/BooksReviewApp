using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Permission;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.PermissionValidators
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
