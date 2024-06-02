using BooksReviewApp.WebApi.Dtos.Book;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BaseBookDto bookDto)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetAllReviewsByBook()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/genres")]
        public async Task<IActionResult> GetAllGenresByBook()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
