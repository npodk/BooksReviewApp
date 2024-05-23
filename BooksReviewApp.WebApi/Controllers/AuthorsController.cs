using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
