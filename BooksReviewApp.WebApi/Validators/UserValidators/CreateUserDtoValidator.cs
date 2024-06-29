using BooksReviewApp.WebApi.Dtos.User;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : BaseUserDtoValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }

}
