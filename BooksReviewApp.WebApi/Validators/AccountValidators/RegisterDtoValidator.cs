using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Account;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.AccountValidators
{
    public class RegisterDtoValidator : BaseValidator<RegisterDto>
    {
        public RegisterDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.UserName)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("UsernameIsRequired"))
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("EmailIsRequired"))
                .ApplyEmailRules(localizationService);

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"))
                .ApplyPasswordRules(localizationService);

            RuleFor(dto => dto.ConfirmPassword)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("ConfirmPasswordIsRequired"))
                .Equal(dto => dto.Password).WithMessage(localizationService.GetValidationMessage("PasswordsDoNotMatch"));
        }
    }
}
