using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Services.EF;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BooksReviewApp.Tests.Common
{
    public abstract class BaseCrudServiceTests<TService, TEntity, TContext>
        where TService : BaseDbCrudService<TEntity, TContext>
        where TEntity : class, IModel
        where TContext : DbContext
    {
        protected Mock<DbSet<TEntity>> _mockDbSet;
        protected Mock<TContext> _mockDbContext;
        protected TService _service;

        protected BaseCrudServiceTests()
        {
            _mockDbSet = new Mock<DbSet<TEntity>>();
            _mockDbContext = new Mock<TContext>();

            SetUpMocks();

            _service = CreateService();
        }

        protected abstract TService CreateService();

        private void SetUpMocks()
        {
            var data = new List<TEntity>().AsQueryable();

            _mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockDbSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockDbContext.Setup(c => c.Set<TEntity>()).Returns(_mockDbSet.Object);
        }
    }
}
