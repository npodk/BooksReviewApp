using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserDbService _userDbService;
        private readonly IMapper _mapper;

        public UsersController(IUserDbService userDbService, IMapper mapper)
        {
            _userDbService = userDbService ?? throw new ArgumentNullException(nameof(userDbService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userEntities = await _userDbService.GetAllAsync();
            var users = _mapper.Map<IEnumerable<ReadUserDto>>(userEntities);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var userEntity = await _userDbService.GetByIdAsync(id);
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
            var createdUser = await _userDbService.CreateAsync(userEntity);
            return Ok(createdUser.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var updatedUser = await _userDbService.UpdateAsync(userEntity);
            return Ok(updatedUser);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchUser([FromBody] PatchUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var patchedUser = await _userDbService.PatchAsync(userEntity);
            return Ok(patchedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var result = await _userDbService.DeleteAsync(id);

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
