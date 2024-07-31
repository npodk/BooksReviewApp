using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Services;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class CreateUserDtoValidator : BaseUserDtoValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("PasswordIsRequired"))
                .ApplyPasswordRules(localizationService);
        }
    }
}
