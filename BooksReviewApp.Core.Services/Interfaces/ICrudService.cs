namespace BooksReviewApp.Core.Services.Interfaces
{
    public interface ICrudService<T> : IService where T : class
    {
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
    }
}
