using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Services.AspNet.Identity.Entities;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IPermissionService : ICrudService<Permission>
    {
        Task<bool> AssignPermissionToRoleAsync(Guid roleId, Guid permissionId);

        Task<bool> RemovePermissionFromRoleAsync(Guid roleId, Guid permissionId);
    }
}
