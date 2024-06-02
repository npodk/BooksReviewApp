using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Core.Database
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
