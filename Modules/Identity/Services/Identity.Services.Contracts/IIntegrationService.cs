using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Contracts
{
    public interface IIntegrationService
    {
        Task<IdentityResult> RegisterAsync(ApplicationUser applicationUser, string password);

        Task<IdentityResult> UpdateAccountAsync(UpdateAccountModel updateAccount);

        Task<IdentityResult> PatchAccountAsync(PatchAccountModel patchAccount);

        Task<IdentityResult> DeleteAccountAsync(Guid userId);

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePassword);
    }
}
