using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Account;
using Identity.WebApi.Extensions;

namespace Identity.WebApi.Validators.AccountValidators
{
    public class UpdateAccountDtoValidator : BaseValidator<UpdateAccountDto>
    {
        public UpdateAccountDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("UsernameIsRequired"))
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("EmailIsRequired"))
                .ApplyEmailRules(localizationService);
        }   
    }
}
