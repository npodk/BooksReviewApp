using Microsoft.AspNetCore.Http;

namespace BooksReviewApp.WebApi.Interfaces
{
    public interface IExceptionHandler
    {
        Type ExceptionType { get; }

        List<string> HandleException(HttpContext context, Exception exception);
    }
}
