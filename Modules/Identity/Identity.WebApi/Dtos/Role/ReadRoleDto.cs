using Identity.WebApi.Dtos.Permission;

namespace Identity.WebApi.Dtos.Role
{
    public class ReadRoleDto : RoleDto
    {
        public Guid Id { get; set; }

        public ICollection<PermissionDto> RolePermissions { get; set; }
    }
}
