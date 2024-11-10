using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Account;
using Identity.WebApi.Extensions;

namespace Identity.WebApi.Validators.AccountValidators
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
