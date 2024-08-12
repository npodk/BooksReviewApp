using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Services;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class PatchUserDtoValidator : BaseValidator<PatchUserDto>
    {
        public PatchUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(dto => dto.Username)
                .NotNull().When(dto => dto.Username != null)
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotNull().When(dto => dto.Email != null)
                .ApplyEmailRules(localizationService);

            RuleFor(dto => dto.Password)
                .NotNull().When(dto => dto.Password != null)
                .ApplyPasswordRules(localizationService);
        }
    }
}
