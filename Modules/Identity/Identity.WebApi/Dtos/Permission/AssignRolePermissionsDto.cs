namespace Identity.WebApi.Dtos.Permission
{
    public class AssignRolePermissionsDto
    {
        public Guid RoleId { get; set; }

        public List<Guid> PermissionIds { get; set; } = new List<Guid>();
    }
}
