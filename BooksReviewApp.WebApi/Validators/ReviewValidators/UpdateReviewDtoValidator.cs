using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Review;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.ReviewValidators
{
    public class UpdateReviewDtoValidator : BaseValidator<UpdateReviewDto>
    {
        public UpdateReviewDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            Include(new CreateReviewDtoValidator(localizationService));
        }
    }
}
