using BooksReviewApp.Database;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Implementation;
using BooksReviewApp.Tests.Common;
using Moq;

namespace BooksReviewApp.Services.Tests
{
    public class AuthorServiceTests : BaseCrudServiceTests<AuthorService, Author, LibraryDbContext>
    {
        protected override AuthorService CreateService()
        {
            return new AuthorService(_mockDbContext.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddEntityAndSaveChanges()
        {
            // Arrange
            var author = new Author
            {
                Name = "John",
                Surname = "Doe",
                Biography = "Author's biography"
            };

            _mockDbSet.Setup(m => m.Add(It.IsAny<Author>())).Verifiable();
            _mockDbContext.Setup(m => m.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _service.CreateAsync(author);

            // Assert
            _mockDbSet.Verify(m => m.Add(It.IsAny<Author>()), Times.Once);
            _mockDbContext.Verify(m => m.SaveChangesAsync(default), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(author.Name, result.Name);
            Assert.Equal(author.Surname, result.Surname);
            Assert.Equal(author.Biography, result.Biography);
        }
    }
}