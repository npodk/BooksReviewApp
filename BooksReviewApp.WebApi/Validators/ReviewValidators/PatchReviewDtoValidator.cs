using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.WebApi.Dtos.Review;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BooksReviewApp.WebApi.Constants;

namespace BooksReviewApp.WebApi.Validators.ReviewValidators
{
    public class PatchReviewDtoValidator : BaseValidator<PatchReviewDto>
    {
        public PatchReviewDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(dto => dto.Id)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("IdNotDefault"));

            RuleFor(dto => dto.Text)
                .NotNull().When(dto => dto.Text != null)
                .WithMessage(localizationService.GetValidationMessage("ReviewTextIsRequired"))
                .MaximumLength(ReviewValidation.MaxTextLength)
                .WithMessage(localizationService.GetValidationMessage("ReviewTextMaxLength", ReviewValidation.MaxTextLength));

            RuleFor(dto => dto.Rating)
                .NotNull().When(dto => dto.Rating != null)
                .InclusiveBetween(ReviewValidation.MinRating, ReviewValidation.MaxRating)
                .WithMessage(localizationService.GetValidationMessage("ReviewRatingOutOfRange", ReviewValidation.MinRating, ReviewValidation.MaxRating));

            RuleFor(dto => dto.BookId)
                .NotNull().When(dto => dto.BookId != null)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("BookIdIsRequired"));

            RuleFor(dto => dto.UserId)
                .NotNull().When(dto => dto.UserId != null)
                .NotEqual(Guid.Empty).WithMessage(localizationService.GetValidationMessage("UserIdIsRequired"));
        }
    }
}
