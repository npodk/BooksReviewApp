using BooksReviewApp.WebApi.Dtos.User;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class BaseUserDtoValidator<T> : AbstractValidator<T> where T : BaseUserDto
    {
        public BaseUserDtoValidator()
        {
            RuleFor(dto => dto.Username)
                .MaximumLength(100).WithMessage("Username must not exceed 100 characters.");

            RuleFor(dto => dto.Email)
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(dto => dto.Password)
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$").WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.");
        }
    }
}
