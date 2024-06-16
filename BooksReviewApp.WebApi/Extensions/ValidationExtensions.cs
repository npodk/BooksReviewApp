using FluentValidation;

namespace BooksReviewApp.WebApi.Extensions
{
    public static class ValidationExtensions
    {
        public static async Task<(bool IsValid, IEnumerable<string> Errors)> ValidateAsync<T>(this T model, IValidator<T> validator)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (validator == null) throw new ArgumentNullException(nameof(validator));

            var validationResult = await validator.ValidateAsync(model);
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            return validationResult.IsValid
                ? (true, Enumerable.Empty<string>())
                : (false, errors);
        }
    }
}
