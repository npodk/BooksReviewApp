using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : BaseValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("UsernameIsRequired"))
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("EmailIsRequired"))
                .ApplyEmailRules(localizationService);

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"))
                .ApplyPasswordRules(localizationService);
        }
    }
}
