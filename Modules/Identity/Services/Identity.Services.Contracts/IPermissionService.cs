using BooksReviewApp.Core.Services.Interfaces;
using Identity.Domain.Entities;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IPermissionService : ICrudService<Permission>
    {
        Task<bool> AssignPermissionsToRoleAsync(Guid roleId, List<Guid> permissionIds);

        Task<bool> RemovePermissionFromRoleAsync(Guid roleId, Guid permissionId);
    }
}
