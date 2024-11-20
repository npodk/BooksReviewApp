using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : BaseUserDtoValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"))
                .ApplyPasswordRules(localizationService);

            RuleFor(dto => dto.ConfirmPassword)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("ConfirmPasswordIsRequired"))
                .Equal(dto => dto.Password).WithMessage(localizationService.GetValidationMessage("PasswordsDoNotMatch"));
        }
    }
}
