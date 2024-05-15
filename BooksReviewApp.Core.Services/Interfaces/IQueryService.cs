namespace BooksReviewApp.Core.Services.Interfaces
{
    public interface IQueryService<T> : IService where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
