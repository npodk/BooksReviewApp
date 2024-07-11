using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage("Username is required.")
                .ApplyUsernameRules();

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .ApplyEmailRules();

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .ApplyPasswordRules();
        }
    }

}
