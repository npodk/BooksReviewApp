using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Account;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.AccountValidators
{
    public class ChangePasswordDtoValidator : BaseValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.UserId)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"));

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"))
                .ApplyPasswordRules(localizationService);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage(localizationService.GetValidationMessage("ConfirmPasswordIsRequired"))
                .Equal(x => x.NewPassword)
                .WithMessage(localizationService.GetValidationMessage("PasswordsDoNotMatch"));
        }
    }
}
