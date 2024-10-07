using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BooksReviewApp.WebApi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .SelectMany(kvp => kvp.Value.Errors.Select(e => new ValidationFailure(kvp.Key, e.ErrorMessage)))
                    .ToList();

                throw new ValidationException(errors);
            }
        }
    }
}
