using Identity.Domain.Entities;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();
    }
}
