using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
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
        public async Task<IActionResult> GetAllUsers()
        {
            var userEntities = await _userService.GetAllAsync();
            var users = _mapper.Map<IEnumerable<ReadUserDto>>(userEntities);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var userEntity = await _userService.GetByIdAsync(id);
            if (userEntity == null)
            {
                return Ok(null);
            }

            var userDto = _mapper.Map<ReadUserDto>(userEntity);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var createdUser = await _userService.CreateAsync(userEntity);
            return Ok(createdUser.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var updatedUser = await _userService.UpdateAsync(userEntity);
            return Ok(updatedUser);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchUser([FromBody] PatchUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var patchedUser = await _userService.PatchAsync(userEntity);
            return Ok(patchedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            return Ok(result);
        }

        // TO-DO: Should be implemented
        [HttpGet("{id}/favorites")]
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
    }
}
