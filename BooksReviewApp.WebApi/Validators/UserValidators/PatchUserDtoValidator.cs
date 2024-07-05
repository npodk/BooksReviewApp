using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Interfaces;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class PatchUserDtoValidator : BaseUserDtoValidator<PatchUserDto>
    {
        public PatchUserDtoValidator(ILocalizationService localizationService) : base(localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage("Id cannot be the default Guid.");
        }
    }
}
