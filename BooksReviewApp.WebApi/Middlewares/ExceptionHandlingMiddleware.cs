using BooksReviewApp.WebApi.Interfaces;
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
                var message = handler.HandleException(context, exception);
                await WriteResponseAsync(response, message);
                return;
            }

            // Default response if no specific handler is found
            await WriteResponseAsync(response, ExceptionHandling.DefaultErrorMessage);
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
