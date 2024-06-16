using BooksReviewApp.WebApi.Dtos.Genre;
using FluentValidation;

namespace BooksReviewApp.WebApi.Validators.GenreValidators
{
    public class CreateGenreDtoValidator : AbstractValidator<CreateGenreDto>
    {
        public CreateGenreDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");
        }
    }
}
