using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class UpdateUserDtoValidator : BaseValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            Include(new CreateUserDtoValidator(localizationService));
        }
    }
}
