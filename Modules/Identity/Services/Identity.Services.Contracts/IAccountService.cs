using Microsoft.AspNetCore.Identity;

namespace BooksReviewApp.Services.Contracts.Interfaces.Identity
{
    public interface IAccountService
    {
        Task<IdentityResult> UpdateAccountAsync(Guid userId, string username, string email);

        Task<IdentityResult> DeleteAccountAsync(Guid userId);
    }
}
