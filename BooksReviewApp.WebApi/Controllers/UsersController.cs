using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/favorites")]
        public async Task<IActionResult> GetAllFavoritesByUser()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetAllReviewsByUser()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
