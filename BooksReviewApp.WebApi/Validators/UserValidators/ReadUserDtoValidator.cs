using FluentValidation;
using BooksReviewApp.WebApi.Dtos.User;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class ReadUserDtoValidator : AbstractValidator<ReadUserDto>
    {
        public ReadUserDtoValidator()
        {
            RuleFor(dto => dto.Id).NotEmpty();
            RuleFor(dto => dto.Username).NotEmpty().MaximumLength(UserValidation.MaxUsernameLength);
            RuleFor(dto => dto.Email).NotEmpty().MaximumLength(UserValidation.MaxEmailLength).EmailAddress();
            RuleFor(dto => dto.Password).NotEmpty().MaximumLength(UserValidation.MaxPasswordLength);
            RuleFor(dto => dto.FavoriteBooks).NotNull();
            RuleForEach(dto => dto.FavoriteBooks);
            RuleFor(dto => dto.Reviews).NotNull();
        }
    }
}
