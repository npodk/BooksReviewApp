using BooksReviewApp.Services.AspNet.Identity;
using BooksReviewApp.Services.AspNet.Identity.Entities;
using BooksReviewApp.Services.Contracts.Interfaces.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Services.Implementation.Identity
{
    public class RoleService : IRoleService
    {
        private readonly AspIdentityDbContext _context;

        public RoleService(AspIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetRolesWithPermissionsAsync()
        {
            return await _context.Roles
                                 .Include(r => r.RolePermissions)
                                 .ThenInclude(rp => rp.Permission)
                                 .ToListAsync();
        }
    }
}
