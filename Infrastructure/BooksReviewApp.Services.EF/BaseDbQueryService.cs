using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.EF
{
    public class BaseDbQueryService<T, TContext> : BaseDbService<T, TContext>, IQueryService<T>
        where T : class, IModel
        where TContext : DbContext
    {
        protected IQueryable<T> DbSetAsNoTrackingIncludeAll { get; set; }

        public BaseDbQueryService(TContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
