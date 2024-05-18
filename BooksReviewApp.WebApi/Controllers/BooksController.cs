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
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook()
        {
            return Ok();
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetAllReviewsByBook()
        {
            return Ok();
        }

        [HttpGet("{id}/genres")]
        public async Task<IActionResult> GetAllGenresByBook()
        {
            return Ok();
        }
    }
}
