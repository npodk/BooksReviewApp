using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Core.Services.Models;
using BooksReviewApp.WebApi.Dtos.Review;
using BooksReviewApp.WebApi.Extensions;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.ReviewValidators
{
    public class CreateReviewDtoValidator : BaseValidator<CreateReviewDto>
    {
        public CreateReviewDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Text)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("ReviewTextIsRequired"))
                .ApplyReviewTextRules(localizationService);

            RuleFor(dto => dto.Rating)
                .NotEmpty().WithMessage(localizationService.GetValidationMessage("ReviewRatingIsRequired"))
                .ApplyReviewRatingRules(localizationService);

            RuleFor(dto => dto.BookId)
                .NotEqual(Guid.Empty)
                .WithMessage(localizationService.GetValidationMessage("BookIdIsRequired"));

            RuleFor(dto => dto.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage(localizationService.GetValidationMessage("UserIdIsRequired"));
        }
    }
}
