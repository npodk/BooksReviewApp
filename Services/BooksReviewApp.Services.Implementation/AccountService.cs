using BooksReviewApp.Services.AspNet.Identity.Models;
using BooksReviewApp.Services.Contracts.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BooksReviewApp.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> UpdateAccountAsync(Guid userId, string username, string email)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            user.UserName = username;
            user.Email = email;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteAccountAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            return await _userManager.DeleteAsync(user);
        }
        
    }
}
