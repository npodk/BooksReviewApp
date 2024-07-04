using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BooksReviewApp.WebApi.Interfaces
{
    public interface IExceptionHandler
    {
        Type ExceptionType { get; }

        string HandleException(HttpContext context, Exception exception);
    }
}
