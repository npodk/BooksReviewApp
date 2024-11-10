using AutoMapper;
using Identity.Domain.Entities;
using Identity.Domain.Models;
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
        private readonly IIntegrationService _integrationService;

        public AccountController(
            IMapper mapper,
            IIntegrationService integrationService)
        {
            _mapper = mapper;
            _integrationService = integrationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(registerDto);

            var result = await _integrationService.RegisterAsync(applicationUser, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { userId = applicationUser.Id });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var changePasswordModel = _mapper.Map<ChangePasswordModel>(changePasswordDto);

            var result = await _integrationService.ChangePasswordAsync(changePasswordModel);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password changed successfully.");
        }

        [Authorize]
        [HttpPut("update-account")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDto updateAccountDto)
        {
            var updateAccount = _mapper.Map<UpdateAccountModel>(updateAccountDto);

            var result = await _integrationService.UpdateAccountAsync(updateAccount);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Account updated successfully.");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAccount(Guid id, [FromBody] PatchAccountDto patchAccountDto)
        {
            var patchAccountModel = _mapper.Map<PatchAccountModel>(patchAccountDto);

            var result = await _integrationService.PatchAccountAsync(patchAccountModel);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Account updated successfully.");
        }

        [Authorize]
        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteAccount(Guid userId)
        {
            var result = await _integrationService.DeleteAccountAsync(userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Account deleted successfully.");
        }
    }
}
