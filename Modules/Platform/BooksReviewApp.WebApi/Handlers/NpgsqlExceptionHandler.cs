using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace BooksReviewApp.WebApi.Handlers
{
    public class NpgsqlExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<NpgsqlExceptionHandler> _logger;

        public Type ExceptionType => typeof(NpgsqlException);

        public NpgsqlExceptionHandler(ILogger<NpgsqlExceptionHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public List<string> HandleException(HttpContext context, Exception exception)
        {
            var dbEx = (NpgsqlException)exception;
            _logger.LogError("Database error occurred: {Message}, StackTrace: {StackTrace}, InnerException: {InnerException}",
                    dbEx.Message, dbEx.StackTrace, dbEx.InnerException?.Message);
            return new List<string> { "Database error occurred" };
        }
    }
}
