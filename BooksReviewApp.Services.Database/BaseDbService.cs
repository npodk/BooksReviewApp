using BooksReviewApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Database
{
    public class BaseDbService<T> : IService where T : class
    {
        private DbSet<T> _dbSet;

        protected internal DbSet<T> DbSet
        {
            get => _dbSet;
            internal set => _dbSet = value;
        }
    }
}
