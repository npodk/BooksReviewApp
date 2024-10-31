using BooksReviewApp.Services.AspNet.Identity.Entities;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesWithPermissionsAsync();
    }
}
