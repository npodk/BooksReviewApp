using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();

        Task<IdentityResult> UpdateRoleAsync(string roleId, string roleName);
    }
}
