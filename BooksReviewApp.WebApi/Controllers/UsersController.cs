using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.Services.EF.Interfaces;
using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.WebApi.Validators.UserValidators;
using FluentValidation;
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
            try
            {
                var userEntities = await _userDbService.GetAllAsync();
                var users = _mapper.Map<IEnumerable<ReadUserDto>>(userEntities);

                var validator = new ReadUserDtoValidator();
                var validationResults = new List<(Guid UserId, string ErrorMessage)>();

                foreach (var user in users)
                {
                    var validationResult = await validator.ValidateAsync(user);
                    if (!validationResult.IsValid)
                    {
                        validationResults.AddRange(validationResult.Errors.Select(e => (user.Id, e.ErrorMessage)));
                    }
                }

                if (validationResults.Any())
                {
                    var errors = validationResults
                        .GroupBy(vr => vr.UserId)
                        .Select(g => new { UserId = g.Key, Errors = g.Select(vr => vr.ErrorMessage).ToList() });
                    return BadRequest(new { Message = "Validation failed.", Errors = errors });
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "retrieving all users");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            try
            {
                var userEntity = await _userDbService.GetByIdAsync(id);
                if (userEntity == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                var userDto = _mapper.Map<ReadUserDto>(userEntity);
                var (isValid, errors) = await ValidateAsync(userDto, new ReadUserDtoValidator());
                if (!isValid)
                {
                    return BadRequest(new { Message = "Validation failed.", Errors = errors });
                }

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"retrieving the user with ID {id}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                var (isValid, errors) = await ValidateAsync(userDto, new CreateUserDtoValidator());
                if (!isValid)
                {
                    return BadRequest(new { Message = "Validation failed.", Errors = errors });
                }

                var userEntity = _mapper.Map<User>(userDto);
                var createdUser = await _userDbService.CreateAsync(userEntity);
                return Ok(createdUser.Id);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "creating the user");
            }
        }

        // TO-DO: Right now it is throwing an exception, need to fix it
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            try
            {
                var userEntity = _mapper.Map<User>(userDto);
                var updatedUser = await _userDbService.UpdateAsync(userEntity);
                if (updatedUser == null)
                {
                    return NotFound($"User with ID {userDto.Id} not found.");
                }
                return Ok(updatedUser.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the user with ID {userDto.Id}: {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> PatchUser([FromBody] UpdateUserDto userDto)
        {
            try
            {
                var userEntity = _mapper.Map<User>(userDto);
                var updatedUser = await _userDbService.PatchAsync(userEntity);
                if (updatedUser == null)
                {
                    return NotFound($"User with ID {userDto.Id} not found.");
                }
                return Ok(updatedUser.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the user with ID {userDto.Id}: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            try
            {
                var result = await _userDbService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound($"User with ID {id} not found.");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the user with ID {id}: {ex.Message}");
            }
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

        private async Task<(bool IsValid, IEnumerable<string> Errors)> ValidateAsync<T>(T model, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                return (false, errors);
            }
            return (true, Enumerable.Empty<string>());
        }

        private IActionResult HandleException(Exception ex, string action)
        {
            return StatusCode(500, $"An error occurred while {action}: {ex.Message}");
        }
    }
}
