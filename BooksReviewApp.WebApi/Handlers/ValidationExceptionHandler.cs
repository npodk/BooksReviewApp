using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BooksReviewApp.WebApi.Handlers
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ValidationExceptionHandler> _logger;

        public Type ExceptionType => typeof(ValidationException);

        public ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<string> HandleException(HttpContext context, Exception exception)
        {
            var valEx = (ValidationException)exception;

            var errors = valEx.Errors.Select(e => e.ErrorMessage);
            _logger.LogError(exception, "Validation error occurred. Message: {Message}, StackTrace: {StackTrace}",
                valEx.Message, exception.StackTrace);

            return errors.ToList();
        }
    }
}
