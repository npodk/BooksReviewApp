using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Controllers;
using BooksReviewApp.WebApi.Dtos.Author;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BooksReviewApp.WebApi.Tests.Controllers
{
    public class AuthorsControllerTests
    {
        private readonly Mock<IAuthorService> _mockAuthorService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AuthorsController _controller;

        public AuthorsControllerTests()
        {
            _mockAuthorService = new Mock<IAuthorService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AuthorsController(_mockAuthorService.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateAuthor_ShouldReturnOkResultWithCreatedAuthorId()
        {
            // Arrange
            var authorDto = new CreateAuthorDto
            {
                Name = BooksReviewApp.Tests.Common.Constants.DefaultAuthor.Name,
                Surname = BooksReviewApp.Tests.Common.Constants.DefaultAuthor.Surname,
                Biography = BooksReviewApp.Tests.Common.Constants.DefaultAuthor.Biography,
            };

            var authorEntity = new Author
            {
                Id = Guid.NewGuid(),
                Name = authorDto.Name,
                Surname = authorDto.Surname,
                Biography = authorDto.Biography
            };

            _mockMapper.Setup(m => m.Map<Author>(authorDto)).Returns(authorEntity);
            _mockAuthorService.Setup(s => s.CreateAsync(It.IsAny<Author>())).ReturnsAsync(authorEntity);

            // Act
            var result = await _controller.CreateAuthor(authorDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(authorEntity.Id, okResult.Value);

            _mockMapper.Verify(m => m.Map<Author>(authorDto), Times.Once);
            _mockAuthorService.Verify(s => s.CreateAsync(It.IsAny<Author>()), Times.Once);
        }
    }
}
