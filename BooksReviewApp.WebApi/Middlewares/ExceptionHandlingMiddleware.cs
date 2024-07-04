using BooksReviewApp.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using System.Text.Json;

namespace BooksReviewApp.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private const string DefaultErrorMessage = "An unexpected error occurred.";

        private readonly RequestDelegate _next;
        private readonly IEnumerable<IExceptionHandler> _exceptionHandlers;

        public ExceptionHandlingMiddleware(RequestDelegate next, IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            _next = next;
            _exceptionHandlers = exceptionHandlers;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;

            foreach (var handler in _exceptionHandlers)
            {
                if (handler.ExceptionType == exception.GetType())
                {
                    var message = handler.HandleException(context, exception);
                    await WriteResponseAsync(response, message);
                    return;
                }
            }

            // Default response if no specific handler is found
            await WriteResponseAsync(response, DefaultErrorMessage);
        }

        private async Task WriteResponseAsync(HttpResponse response, string message)
        {
            var responseModel = new { Success = false, Message = message };
            var jsonResponse = JsonSerializer.Serialize(responseModel);
            response.StatusCode = StatusCodes.Status404NotFound;
            await response.WriteAsync(jsonResponse);
        }
    }
}
