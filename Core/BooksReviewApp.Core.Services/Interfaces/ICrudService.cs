using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Core.Services.Interfaces
{
    public interface ICrudService<T> : IQueryService<T> where T : IModel
    {
        Task<T> CreateAsync(T model);
        Task<T?> UpdateAsync(T model);
        Task<T?> PatchAsync(T model);
        Task<bool> DeleteAsync(Guid id);
    }
}
