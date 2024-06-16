using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Core.Services.Interfaces
{
    public interface IQueryService<T> : IService<T> where T : IModel
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T?>> GetAllAsync();
    }
}
