using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Extensions;
using BooksReviewApp.WebApi.Services;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.UserValidators
{
    public class PatchUserDtoValidator : BaseValidator<PatchUserDto>
    {
        public PatchUserDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"))
                .When(dto => dto.Id != null);

            When(dto => dto.Username != null, () =>
            {
                RuleFor(dto => dto.Username)
                    .ApplyUsernameRules(localizationService);
            });

            When(dto => dto.Email != null, () =>
            {
                RuleFor(dto => dto.Email)
                    .ApplyEmailRules(localizationService);
            });

            When(dto => dto.Password != null, () =>
            {
                RuleFor(dto => dto.Password)
                    .ApplyPasswordRules(localizationService);
            });
        }
    }
}
