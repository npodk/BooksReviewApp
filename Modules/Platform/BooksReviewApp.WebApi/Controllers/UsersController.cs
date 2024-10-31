using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksReviewApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IAccountService accountService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            var identityResult = await _accountService.UpdateAccountAsync(userDto.Id, userDto.Username, userDto.Email);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

            var userEntity = _mapper.Map<User>(userDto);
            var updatedUser = await _userService.UpdateAsync(userEntity);
            return Ok(updatedUser);
        }

        /*
        [HttpPatch]
        public async Task<IActionResult> PatchUser([FromBody] PatchUserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            var patchedUser = await _userService.PatchAsync(userEntity);
            return Ok(patchedUser);
        }
        */

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var identityResult = await _accountService.DeleteAccountAsync(id);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors);
            }

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
