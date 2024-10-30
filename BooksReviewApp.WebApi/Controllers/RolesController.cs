using AutoMapper;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using BooksReviewApp.WebApi.Dtos.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.WebApi.Controllers
{
    // [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> GetRoles()
        {
            var roleEntities = await _roleService.GetRolesWithPermissionsAsync();
            var roles = _mapper.Map<IEnumerable<ReadRoleDto>>(roleEntities);

            return Ok(roles);
        }

        [HttpDelete("delete/{roleName}")]
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
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto assignRoleDto)
        {
            var user = await _userManager.FindByIdAsync(assignRoleDto.UserId.ToString());
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExist = await _roleManager.RoleExistsAsync(assignRoleDto.RoleName);
            if (!roleExist)
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
    }
}
