namespace Identity.WebApi.Dtos.Permission
{
    public class DeleteRolePermissionDto
    {
        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }
    }
}
