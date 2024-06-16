using FluentValidation;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(Constants.MaxUsernameLength).WithMessage($"Username must not exceed {Constants.MaxUsernameLength} characters.");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(Constants.MaxEmailLength).WithMessage($"Email must not exceed {Constants.MaxEmailLength} characters.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(Constants.MinPasswordLength).WithMessage($"Password must be at least {Constants.MinPasswordLength} characters long.")
                .MaximumLength(Constants.MaxPasswordLength).WithMessage($"Password must not exceed {Constants.MaxPasswordLength} characters.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$").WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.");
        }
    }
}
