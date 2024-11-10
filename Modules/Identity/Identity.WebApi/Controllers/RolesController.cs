using AutoMapper;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using Identity.Domain.Entities;
using Identity.WebApi.Dtos.Role;
using Identity.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RolesController(
            RoleManager<Role> roleManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IRoleService roleService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpPost("create")]
        [Permission("Roles.Post")]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleDto.RoleName);
            if (roleExist)
            {
                return BadRequest("Role already exists.");
            }

            var result = await _roleManager.CreateAsync(new Role(roleDto.RoleName));
            if (result.Succeeded)
            {
                return Ok(new { Role = roleDto.RoleName });
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Permission("Roles.Get")]
        public async Task<IActionResult> GetRoles()
        {
            var roleEntities = await _roleService.GetRolesWithPermissionsAsync();
            var roles = _mapper.Map<IEnumerable<ReadRoleDto>>(roleEntities);

            return Ok(roles);
        }

        [HttpPut]
        [Permission("Roles.Put")]
        public async Task<IActionResult> UpdateRole([FromRoute] string roleId, [FromBody] RoleDto roleDto)
        {
            var result = await _roleService.UpdateRoleAsync(roleId, roleDto.RoleName);

            if (result.Succeeded)
            {
                return Ok($"Role {roleId} updated to {roleDto.RoleName}.");
            }

            return BadRequest(result.Errors);
        }

        [HttpDelete("delete/{roleName}")]
        [Permission("Roles.Delete")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return NotFound("Role not found.");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok($"Role {roleName} deleted.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("assign")]
        [Permission("Roles.Assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto assignRoleDto)
        {
            var user = await GetUser(assignRoleDto.UserId);
            if (user == null) return NotFound("User not found.");

            if (await RoleExists(assignRoleDto.RoleName))
            {
                return BadRequest("Role does not exist.");
            }

            var result = await _userManager.AddToRoleAsync(user, assignRoleDto.RoleName);
            if (result.Succeeded)
            {
                return Ok($"User {user.UserName} assigned to role {assignRoleDto.RoleName}.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("unassign")]
        [Permission("Roles.Assign")]
        public async Task<IActionResult> UnassignRole([FromBody] AssignRoleDto assignRoleDto)
        {
            var user = await GetUser(assignRoleDto.UserId);
            if (user == null) return NotFound("User not found.");

            if (await RoleExists(assignRoleDto.RoleName))
            {
                return BadRequest("Role does not exist.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, assignRoleDto.RoleName);
            if (result.Succeeded)
            {
                return Ok($"User {user.UserName} unassigned from role {assignRoleDto.RoleName}.");
            }

            return BadRequest(result.Errors);
        }

        private async Task<bool> RoleExists(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        private async Task<ApplicationUser> GetUser(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
    }
}
