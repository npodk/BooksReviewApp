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
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoriteById()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFavorite()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFavorite()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite()
        {
            return Ok();
        }
    }
}
