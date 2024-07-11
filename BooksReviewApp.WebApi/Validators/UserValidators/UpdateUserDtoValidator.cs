using BooksReviewApp.WebApi.Dtos.User;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage("Id cannot be the default Guid.");

            Include(new CreateUserDtoValidator());
        }
    }
}
