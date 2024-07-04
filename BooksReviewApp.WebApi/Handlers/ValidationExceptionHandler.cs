using BooksReviewApp.WebApi.Interfaces;
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

        public string HandleException(HttpContext context, Exception exception)
        {
            var valEx = (ValidationException)exception;
            string errorMessage = string.Join("; ", valEx.Errors);
            _logger.LogError("Validation error occurred. Message: {Message}, Errors: {Errors}, StackTrace: {StackTrace}, InnerException: {InnerException}",
                valEx.Message, errorMessage, valEx.StackTrace, valEx.InnerException?.Message);

            return "Validation error occurred.";
        }
    }
}
