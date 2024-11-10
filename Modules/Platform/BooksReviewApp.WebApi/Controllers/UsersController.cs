using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using Identity.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Permission("Users.Get")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userEntities = await _userService.GetAllAsync();
            var users = _mapper.Map<IEnumerable<ReadUserDto>>(userEntities);

            return Ok(users);
        }

        [HttpGet("by-id/{id}")]
        [Permission("Users.Get")]
        public Task<IActionResult> GetUserById([FromRoute] Guid id) =>
            GetUserByIdAsync(_userService.GetByIdAsync, id);

        [HttpGet("by-application-id/{id}")]
        [Permission("Users.Get")]
        public Task<IActionResult> GetUserByApplicationId([FromRoute] Guid id) =>
            GetUserByIdAsync(_userService.GetByApplicationUserIdAsync, id);

        // TO-DO: Should be implemented
        [HttpGet("{id}/favorites")]
        [Permission("Favorites.Get")]
        public async Task<IActionResult> GetAllFavoritesByUser()
        {
            try
            {
                await Task.CompletedTask;
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving all favorites for the user: {ex.Message}");
            }
        }

        // TO-DO: Should be implemented
        [HttpGet("{id}/reviews")]
        [Permission("Reviews.Get")]
        public async Task<IActionResult> GetAllReviewsByUser()
        {
            try
            {
                await Task.CompletedTask;
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving all reviews for the user: {ex.Message}");
            }
        }

        private async Task<IActionResult> GetUserByIdAsync(Func<Guid, Task<User?>> userServiceMethod, Guid id)
        {
            var userEntity = await userServiceMethod(id);

            if (userEntity == null)
            {
                return NotFound("User not found.");
            }

            var userDto = _mapper.Map<ReadUserDto>(userEntity);
            return Ok(userDto);
        }
    }
}
