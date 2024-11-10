using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Authentication;
using Identity.WebApi.Extensions;

namespace Identity.WebApi.Validators.AuthenticationValidators
{
    public class LoginDtoValidator : BaseValidator<LoginDto>
    {
        public LoginDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.UserName)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("UsernameIsRequired"))
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"))
                .ApplyPasswordRules(localizationService);
        }
    }
}
