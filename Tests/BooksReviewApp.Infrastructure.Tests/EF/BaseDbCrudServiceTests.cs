using BooksReviewApp.Database;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Infrastructure.Tests.Models;
using BooksReviewApp.Services.EF;
using BooksReviewApp.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BooksReviewApp.Infrastructure.Tests.EF
{
    public class BaseDbCrudServiceTests : BaseCrudServiceTests<BaseDbCrudService<TestEntity, TestDbContext>, TestEntity, TestDbContext>
    {
        protected override BaseDbCrudService<TestEntity, TestDbContext> CreateService()
        {
            return new BaseDbCrudService<TestEntity, TestDbContext>(_mockDbContext.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var model = new TestEntity { Name = "Test" };

            _mockDbSet.Setup(m => m.Add(It.IsAny<TestEntity>())).Verifiable();
            _mockDbContext.Setup(m => m.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _service.CreateAsync(model);

            // Assert
            _mockDbSet.Verify(m => m.Add(It.IsAny<TestEntity>()), Times.Once);
            _mockDbContext.Verify(m => m.SaveChangesAsync(default), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(model.Name, result.Name);
        }
    }
}
