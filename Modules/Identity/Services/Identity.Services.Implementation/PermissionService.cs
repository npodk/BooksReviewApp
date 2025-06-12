using BooksReviewApp.Services.AspNet.Identity;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using BooksReviewApp.Services.EF;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services.Implementation
{
    public class PermissionService : BaseDbCrudService<Permission, AspIdentityDbContext>, IPermissionService
    {
        private readonly AspIdentityDbContext _context;

        public PermissionService(AspIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AssignPermissionsToRoleAsync(Guid roleId, List<Guid> permissionIds)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                return false;
            }

            var existingPermissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId && permissionIds.Contains(rp.PermissionId))
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            var newPermissions = permissionIds.Except(existingPermissions);

            var rolePermissions = newPermissions.Select(permissionId => new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            }).ToList();

            _context.RolePermissions.AddRange(rolePermissions);
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

        private async Task<RolePermission?> GetRolePermissionAsync(Guid roleId, Guid permissionId)
        {
            return await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }
    }
}
