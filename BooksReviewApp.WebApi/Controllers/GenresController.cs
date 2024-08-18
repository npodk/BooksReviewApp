using BooksReviewApp.WebApi.Dtos.Genre;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDto genreDto)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAllBooksByGenre()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
