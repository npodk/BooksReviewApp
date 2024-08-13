using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbService<T, TContext> : IService
        where T : class, IModel
        where TContext : DbContext
    {
        protected readonly TContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected IQueryable<T> DbSetAsNoTracking { get; set; }

        public BaseDbService(TContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
            DbSetAsNoTracking = _dbSet.AsNoTracking();
        }
    }
}
