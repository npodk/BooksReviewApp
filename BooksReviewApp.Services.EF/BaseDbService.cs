using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbService<T> : IService where T : class, IModel
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected internal IQueryable<T> DbSetAsNoTracking { get; set; }

        public BaseDbService(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
            DbSetAsNoTracking = _dbSet.AsNoTracking();
        }
    }
}
