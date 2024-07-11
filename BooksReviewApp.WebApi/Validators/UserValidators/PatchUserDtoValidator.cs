using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class PatchUserDtoValidator : AbstractValidator<PatchUserDto>
    {
        public PatchUserDtoValidator()
        {
            RuleFor(dto => dto.Id).NotEqual(Guid.Empty).WithMessage("Id cannot be the default Guid.");

            RuleFor(dto => dto.Username)
                .ApplyUsernameRules();

            RuleFor(dto => dto.Email)
                .ApplyEmailRules();

            RuleFor(dto => dto.Password)
                .ApplyPasswordRules();
        }
    }
}
