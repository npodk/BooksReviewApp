using BooksReviewApp.WebApi.Dtos.User;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class PatchUserDtoValidator : BaseUserDtoValidator<PatchUserDto>
    {
        public PatchUserDtoValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage("Id cannot be the default Guid.");
        }
    }
}
