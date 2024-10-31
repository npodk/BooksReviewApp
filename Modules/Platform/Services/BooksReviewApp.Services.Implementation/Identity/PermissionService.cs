using BooksReviewApp.Services.AspNet.Identity;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using BooksReviewApp.Services.EF;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Implementation.Identity
{
    public class PermissionService : BaseDbCrudService<Permission, AspIdentityDbContext>, IPermissionService
    {
        private readonly AspIdentityDbContext _context;

        public PermissionService(AspIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AssignPermissionToRoleAsync(Guid roleId, Guid permissionId)
        {
            if (await RolePermissionExistsAsync(roleId, permissionId))
            {
                return true;
            }

            var role = await _context.Roles.FindAsync(roleId);
            var permission = await _context.Permissions.FindAsync(permissionId);

            if (role == null || permission == null)
            {
                return false;
            }

            var rolePermission = new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            };

            _context.RolePermissions.Add(rolePermission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemovePermissionFromRoleAsync(Guid roleId, Guid permissionId)
        {
            var rolePermission = await GetRolePermissionAsync(roleId, permissionId);
            if (rolePermission == null)
            {
                return false;
            }

            _context.RolePermissions.Remove(rolePermission);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> RolePermissionExistsAsync(Guid roleId, Guid permissionId)
        {
            return await _context.RolePermissions.AnyAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }

        private async Task<RolePermission?> GetRolePermissionAsync(Guid roleId, Guid permissionId)
        {
            return await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }
    }
}
