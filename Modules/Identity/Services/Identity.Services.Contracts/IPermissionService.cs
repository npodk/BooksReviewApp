using BooksReviewApp.Core.Services.Interfaces;
using Identity.Domain.Entities;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IPermissionService : ICrudService<Permission>
    {
        Task<bool> AssignPermissionToRoleAsync(Guid roleId, Guid permissionId);

        Task<bool> RemovePermissionFromRoleAsync(Guid roleId, Guid permissionId);
    }
}
