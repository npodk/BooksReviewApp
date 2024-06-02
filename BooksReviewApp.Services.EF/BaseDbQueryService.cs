using BooksReviewApp.Core.Database;
using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Database;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbQueryService<T, TContext> : IQueryService<T> 
        where T : class, IModel
        where TContext : IDbContext
    {
        protected readonly TContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseDbQueryService(TContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} was not found.");
            }

            return entity;
        }
    }
}
