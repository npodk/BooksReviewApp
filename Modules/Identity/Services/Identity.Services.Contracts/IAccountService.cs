using BooksReviewApp.Core.Domain;
using Identity.Domain.Entities;

namespace Identity.Services.Contracts
{
    public interface IAccountService
    {
        Task<Result<Guid>> RegisterAsync(ApplicationUser user, string password);

        Task<Result> UpdateAccountAsync(ApplicationUser updateModel);

        Task<Result> PatchAccountAsync(Guid id, ApplicationUser patchModel);

        Task<Result> DeleteAccountAsync(Guid id);

        Task<Result> ChangePasswordAsync(Guid userId, string oldPassword, string newPassword);
    }
}
