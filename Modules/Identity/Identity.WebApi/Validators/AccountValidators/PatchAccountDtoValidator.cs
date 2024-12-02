using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using FluentValidation;
using Identity.WebApi.Dtos.Account;
using Identity.WebApi.Extensions;

namespace Identity.WebApi.Validators.AccountValidators
{
    public class PatchAccountDtoValidator : BaseValidator<PatchAccountDto>
    {
        public PatchAccountDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(dto => dto.UserName)
                .NotNull().When(dto => dto.UserName != null)
                .ApplyUsernameRules(localizationService);

            RuleFor(dto => dto.Email)
                .NotNull().When(dto => dto.Email != null)
                .ApplyEmailRules(localizationService);
        }
    }
}
