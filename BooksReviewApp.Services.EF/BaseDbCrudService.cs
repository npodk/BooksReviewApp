using BooksReviewApp.Core.Database;
using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbCrudService<T, TContext> : BaseDbQueryService<T, TContext>, ICrudService<T> 
        where T : class, IModel
        where TContext : IDbContext
    {
        public BaseDbCrudService(TContext context) : base(context)
        {
        }

        public async Task<T> CreateAsync(T model)
        {
            
            _dbSet.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> UpdateAsync(T model)
        {
            _dbSet.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
