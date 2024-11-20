using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using Identity.WebApi.Filters;
using Identity.WebApi.Integration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserApplicationService userApplicationService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userApplicationService = userApplicationService;
        }

        [HttpGet]
        [Permission("Users.Get")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userEntities = await _userApplicationService.GetAllUsersAsync();
            var users = _mapper.Map<IEnumerable<ReadUserDto>>(userEntities);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var userEntity = await _userApplicationService.GetUserById(id);
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
            var userModel = _mapper.Map<CreateUserModel>(userDto);
            var userEntity = _mapper.Map<User>(userDto);

            var result = await _userApplicationService.CreateUserAsync(userEntity, userModel);
            return result.IsSucceeded ? Ok(result.Value) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto userDto)
        {
            var updatedUser = _mapper.Map<User>(userDto);
            var updateUserModel = _mapper.Map<UpdateUserModel>(userDto);

            var result = await _userApplicationService.UpdateUserAsync(id, updatedUser, updateUserModel);
            return result.IsSucceeded ? Ok(result.Value) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var result = await _userApplicationService.DeleteUserAsync(id);
            return result.IsSucceeded ? Ok() : BadRequest(result.Message);
        }

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
    }
}
