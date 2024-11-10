using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFavorites()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoriteById()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFavorite()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavorite()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
