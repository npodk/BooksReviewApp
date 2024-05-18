using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Core.Services.Interfaces
{
    public interface IService<T> : IService where T : IModel
    {
    }

    public interface IService
    {
    }
}
