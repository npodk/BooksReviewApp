using BooksReviewApp.WebApi.Dtos.Permission;

namespace BooksReviewApp.WebApi.Dtos.Role
{
    public class ReadRoleDto : RoleDto
    {
        public Guid Id { get; set; }

        public ICollection<PermissionDto> RolePermissions { get; set; }
    }
}
