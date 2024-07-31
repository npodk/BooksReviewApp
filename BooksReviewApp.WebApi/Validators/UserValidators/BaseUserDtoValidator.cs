using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Interfaces;
using BooksReviewApp.WebApi.Services;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class BaseUserDtoValidator<T> : BaseValidator<T> where T : BaseUserDto
    {
        public BaseUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("UsernameIsRequired"))
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("EmailIsRequired"))
                .ApplyEmailRules(localizationService);
        }
    }
}
