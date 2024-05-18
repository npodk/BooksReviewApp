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
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor()
        {
            return Ok();
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooksByAuthor(int authorId)
        {
            return Ok();
        }
    }
}
