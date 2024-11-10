using AutoMapper;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using Identity.Domain.Entities;
using Identity.WebApi.Dtos.Permission;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IMapper _mapper;

        public PermissionsController(IPermissionService permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissionEntities = await _permissionService.GetAllAsync();
            var permissions = _mapper.Map<IEnumerable<PermissionDto>>(permissionEntities);

            return Ok(permissions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] BasePermissionDto permissionDto)
        {
            var permissionEntity = _mapper.Map<Permission>(permissionDto);
            var createdGenre = await _permissionService.CreateAsync(permissionEntity);
            return Ok(createdGenre.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePermission([FromBody] PermissionDto permissionDto)
        {
            var permissionEntity = _mapper.Map<Permission>(permissionDto);
            var updatedPermission = await _permissionService.UpdateAsync(permissionEntity);
            return Ok(updatedPermission);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission([FromRoute] Guid id)
        {
            var result = await _permissionService.DeleteAsync(id);

            return Ok(result);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignPermissionsToRole([FromBody] AssignRolePermissionsDto assignPermissionDto)
        {
            var result = await _permissionService.AssignPermissionsToRoleAsync(assignPermissionDto.RoleId, assignPermissionDto.PermissionIds);

            return result ? Ok() : NotFound();
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemovePermissionFromRole([FromBody] DeleteRolePermissionDto deletePermissionDto)
        {
            var result = await _permissionService.RemovePermissionFromRoleAsync(deletePermissionDto.RoleId, deletePermissionDto.PermissionId);

            return result ? Ok() : NotFound();
        }
    }
}
