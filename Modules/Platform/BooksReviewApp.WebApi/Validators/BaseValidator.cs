using FluentValidation;
using FluentValidation.Results;

namespace BooksReviewApp.WebApi.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var result = base.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return result;
        }
    }
}
