using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BooksReviewApp.Services.Implementation.Identity
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IntegrationService(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IdentityResult> RegisterAsync(ApplicationUser applicationUser, string password)
        {
            var identityResult = await _userManager.CreateAsync(applicationUser, password);
            if (!identityResult.Succeeded) return identityResult;

            var user = CreateUserFromApplicationUser(applicationUser);
            return await TryCreateUserAsync(user, applicationUser);
        }

        public async Task<IdentityResult> UpdateAccountAsync(UpdateAccountModel updateAccount)
        {
            var (applicationUser, user) = await GetUsersAsync(updateAccount.Id);
            if (applicationUser == null || user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            var originalAppUser = CloneUser(applicationUser);
            var originalUser = CloneUser(user);

            UpdateUserDetails(applicationUser, user, updateAccount);
            return await TryUpdateUserAsync(applicationUser, originalAppUser, user, originalUser);
        }

        public async Task<IdentityResult> PatchAccountAsync(PatchAccountModel patchAccount)
        {
            var (applicationUser, user) = await GetUsersAsync(patchAccount.Id);
            if (applicationUser == null || user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            var originalAppUser = CloneUser(applicationUser);
            var originalUser = CloneUser(user);

            if (!string.IsNullOrEmpty(patchAccount.Username))
            {
                applicationUser.UserName = patchAccount.Username;
                user.Username = patchAccount.Username;
            }

            if (!string.IsNullOrEmpty(patchAccount.Email))
            {
                applicationUser.Email = patchAccount.Email;
                user.Email = patchAccount.Email;
            }

            return await TryUpdateUserAsync(applicationUser, originalAppUser, user, originalUser);
        }

        public async Task<IdentityResult> DeleteAccountAsync(Guid userId)
        {
            var (applicationUser, user) = await GetUsersAsync(userId);
            if (applicationUser == null || user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            return await TryDeleteUserAsync(applicationUser, user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(changePassword.UserId.ToString());
            if (applicationUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            var result = await _userManager.ChangePasswordAsync(applicationUser, changePassword.OldPassword, changePassword.NewPassword);

            return result;
        }

        private async Task<(ApplicationUser?, User?)> GetUsersAsync(Guid userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId.ToString());
            var user = applicationUser != null ? await _userService.GetByApplicationUserIdAsync(userId) : null;
            return (applicationUser, user);
        }

        private static void UpdateUserDetails(ApplicationUser applicationUser, User user, UpdateAccountModel updateAccount)
        {
            applicationUser.UserName = updateAccount.Username;
            applicationUser.Email = updateAccount.Email;
            user.Username = updateAccount.Username;
            user.Email = updateAccount.Email;
        }

        private User CreateUserFromApplicationUser(ApplicationUser applicationUser) =>
            new()
            {
                ApplicationUserId = applicationUser.Id,
                Username = applicationUser.UserName,
                Email = applicationUser.Email
            };

        private async Task<IdentityResult> TryCreateUserAsync(User user, ApplicationUser applicationUser)
        {
            try
            {
                await _userService.CreateAsync(user);
                return IdentityResult.Success;
            }
            catch
            {
                await _userManager.DeleteAsync(applicationUser);
                throw;
            }
        }

        private static ApplicationUser CloneUser(ApplicationUser user) => new ApplicationUser
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email
        };

        private static User CloneUser(User user) => new User
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            ApplicationUserId = user.ApplicationUserId
        };

        private async Task<IdentityResult> TryUpdateUserAsync(
            ApplicationUser appUser,
            ApplicationUser originalAppUser,
            User user,
            User originalUser)
        {
            try
            {
                var updateResult = await _userManager.UpdateAsync(appUser);
                if (!updateResult.Succeeded) return updateResult;

                await _userService.UpdateAsync(user);
                return IdentityResult.Success;
            }
            catch
            {
                await _userManager.UpdateAsync(originalAppUser);
                await _userService.UpdateAsync(originalUser);
                throw;
            }
        }

        private async Task<IdentityResult> TryDeleteUserAsync(ApplicationUser applicationUser, User user)
        {
            try
            {
                await _userService.DeleteAsync(user.Id);
                var identityResult = await _userManager.DeleteAsync(applicationUser);
                if (!identityResult.Succeeded)
                {
                    await _userService.CreateAsync(user);
                    return identityResult;
                }
                return identityResult;
            }
            catch (Exception ex)
            {
                await _userService.CreateAsync(user);
                throw new InvalidOperationException("Failed to delete the user account.", ex);
            }
        }
    }
}