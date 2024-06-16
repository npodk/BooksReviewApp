using FluentValidation;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class ReadUserDtoValidator : AbstractValidator<ReadUserDto>
    {
        public ReadUserDtoValidator()
        {
            RuleFor(dto => dto.Id).NotEmpty();
            RuleFor(dto => dto.Username).NotEmpty().MaximumLength(Constants.MaxUsernameLength);
            RuleFor(dto => dto.Email).NotEmpty().MaximumLength(Constants.MaxEmailLength).EmailAddress();
            RuleFor(dto => dto.Password).NotEmpty().MaximumLength(Constants.MaxPasswordLength);
            RuleFor(dto => dto.FavoriteBooks).NotNull();
            RuleForEach(dto => dto.FavoriteBooks);
            RuleFor(dto => dto.Reviews).NotNull();
        }
    }
}
