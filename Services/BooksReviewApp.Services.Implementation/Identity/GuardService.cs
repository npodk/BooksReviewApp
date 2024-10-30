using BooksReviewApp.Services.AspNet.Identity;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Implementation.Identity
{
    public class GuardService : IGuardService
    {
        private readonly AspIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GuardService(AspIdentityDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> UserHasPermissionAsync(Guid userId, string permissionName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                var roleEntity = await _context.Roles
                    .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                    .FirstOrDefaultAsync(r => r.Name == role);

                if (roleEntity != null && roleEntity.RolePermissions.Any(rp => rp.Permission.Name == permissionName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
