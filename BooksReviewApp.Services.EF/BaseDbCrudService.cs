using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbCrudService<T> : ICrudService<T> where T : class, IModel
    {
        private readonly LibraryDbContext _context;
        private DbSet<T> _dbSet;

        public BaseDbCrudService(LibraryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T model)
        {
            _dbSet.Add(model);
            await _context.SaveChangesAsync();
            return model;
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

        public async Task<T> UpdateAsync(T model)
        {
            _dbSet.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
