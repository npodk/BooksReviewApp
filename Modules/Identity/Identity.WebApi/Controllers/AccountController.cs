using AutoMapper;
using Identity.Domain.Entities;
using Identity.Services.Contracts;
using Identity.WebApi.Dtos.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public AccountController(
            IMapper mapper,
            IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(registerDto);

            var result = await _accountService.RegisterAsync(applicationUser, registerDto.Password);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDto updateAccountDto)
        {
            var updateAccount = _mapper.Map<ApplicationUser>(updateAccountDto);

            var result = await _accountService.UpdateAccountAsync(updateAccount);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(true);
        }

        [HttpPatch]
        public async Task<IActionResult> PatchAccount(Guid id, [FromBody] PatchAccountDto patchAccountDto)
        {
            var patchAccount = _mapper.Map<ApplicationUser>(patchAccountDto);

            var result = await _accountService.PatchAccountAsync(id, patchAccount);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(true);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
        {
            var result = await _accountService.DeleteAccountAsync(id);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(true);
        }

        [Authorize]
        [HttpPost("password/change")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _accountService.ChangePasswordAsync(changePasswordDto.UserId, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
            if (!result.IsSucceeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(true);
        }
    }
}
