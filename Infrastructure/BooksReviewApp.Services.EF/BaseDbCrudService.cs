using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.EF
{
    public class BaseDbCrudService<T, TContext> : BaseDbQueryService<T, TContext>, ICrudService<T>
        where T : class, IModel
        where TContext : DbContext
    {
        public BaseDbCrudService(TContext context) : base(context)
        {
        }

        public async Task<T> CreateAsync(T model)
        {
            model.Id = Guid.NewGuid();
            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> CreateWithoutIdAsync(T model)
        {
            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T?> UpdateAsync(T model)
        {
            var entity = await GetByIdAsync(model.Id);

            if (entity == null)
            {
                return null;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<T?> PatchAsync(T model)
        {
            var entity = await GetByIdAsync(model.Id);
            if (entity == null)
            {
                return null;
            }

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(model);
                if (value != null)
                {
                    property.SetValue(entity, value);
                }
            }

            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
