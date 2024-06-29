using BooksReviewApp.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BooksReviewApp.WebApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status404NotFound;

            object responseModel;

            switch (exception)
            {
                case DatabaseException dbEx:
                    _logger.LogError("Database error occurred: {Exception}", dbEx.Message);
                    responseModel = new { Success = false, Message = "Database error occurred." };
                    break;

                case ValidationFailedException valEx:
                    string errorMessage = string.Join("; ", valEx.Errors);
                    _logger.LogError("Validation error occurred. Message: {Exception}, Errors: {Errors}", valEx.Message, errorMessage);
                    responseModel = new { Success = false, Message = "Validation error occurred." };
                    break;

                default:
                    responseModel = new { Success = false, Message = "An error occurred." };
                    break;
            }

            var jsonResponse = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(jsonResponse);
        }
    }
}
