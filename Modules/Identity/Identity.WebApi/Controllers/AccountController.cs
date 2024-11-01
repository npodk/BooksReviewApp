using AutoMapper;
using Identity.Domain.Entities;
using Identity.WebApi.Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        // private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            IMapper mapper,
            // IUserService userService,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            // _userService = userService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(registerDto);
            applicationUser.Id = Guid.NewGuid();

            var result = await _userManager.CreateAsync(applicationUser, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            /*
            var user = new User
            {
                Id = applicationUser.Id,
                Username = registerDto.UserName,
                Email = registerDto.Email
            };

            await _userService.CreateWithoutIdAsync(user);
            */
            return Ok(new { userId = applicationUser.Id });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByIdAsync(changePasswordDto.UserId.ToString());
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password changed successfully.");
        }
    }
}
