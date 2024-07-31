using BooksReviewApp.WebApi.Handlers;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using System.Text.Json;
using static BooksReviewApp.WebApi.Constants.Constants;

namespace BooksReviewApp.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        public ExceptionHandlingMiddleware(RequestDelegate next, IDictionary<Type, IExceptionHandler> exceptionHandlers)
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

            if (_exceptionHandlers.TryGetValue(exception.GetType(), out var handler))
            {
                var messages = handler.HandleException(context, exception);
                await WriteResponseAsync(response, messages);
                return;
            }

            // Default response if no specific handler is found
            var defaultMessages = new List<string> { ExceptionHandling.DefaultErrorMessage };
            await WriteResponseAsync(response, defaultMessages);
        }

        private async Task WriteResponseAsync(HttpResponse response, List<string> messages)
        {
            var responseModel = new { Success = false, Message = messages };
            var jsonResponse = JsonSerializer.Serialize(responseModel);
            response.StatusCode = StatusCodes.Status404NotFound;
            await response.WriteAsync(jsonResponse);
        }
    }
}
