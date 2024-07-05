using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Interfaces;
using FluentValidation;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(UserValidation.MaxUsernameLength)
                .WithMessage(localizationService.GetValidationMessage(nameof(UserValidation.MaxUsernameLength), UserValidation.MaxUsernameLength));

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .WithMessage(localizationService.GetValidationMessage(nameof(UserValidation.MaxEmailLength), UserValidation.MaxEmailLength))
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(UserValidation.MinPasswordLength)
                .WithMessage(localizationService.GetValidationMessage(nameof(UserValidation.MinPasswordLength), UserValidation.MinPasswordLength))
                .MaximumLength(UserValidation.MaxPasswordLength)
                .WithMessage(localizationService.GetValidationMessage(nameof(UserValidation.MaxPasswordLength), UserValidation.MaxPasswordLength))
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")
                .WithMessage(localizationService.GetValidationMessage(nameof(UserValidation.MaxPasswordLength), UserValidation.MaxPasswordLength));
        }
    }
}
