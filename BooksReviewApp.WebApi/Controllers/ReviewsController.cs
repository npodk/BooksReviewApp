using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview()
        {
            return Ok();
        }
    }
}
