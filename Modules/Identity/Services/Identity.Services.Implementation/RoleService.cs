using BooksReviewApp.Services.AspNet.Identity;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Implementation.Identity
{
    public class RoleService : IRoleService
    {
        private readonly AspIdentityDbContext _context;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(AspIdentityDbContext context, RoleManager<Role> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<Role>> GetRolesWithPermissionsAsync()
        {
            return await _context.Roles
                                 .Include(r => r.RolePermissions)
                                 .ThenInclude(rp => rp.Permission)
                                 .ToListAsync();
        }

        public async Task<IdentityResult> UpdateRoleAsync(string roleId, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role not found." });
            }

            if (role.Name != roleName)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Role with the new name already exists." });
                }

                role.Name = roleName;
                var result = await _roleManager.UpdateAsync(role);
                return result;
            }

            return IdentityResult.Failed(new IdentityError { Description = "No changes detected." });
        }
    }
}
