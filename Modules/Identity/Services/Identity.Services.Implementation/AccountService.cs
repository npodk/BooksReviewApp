using BooksReviewApp.Core.Domain;
using Identity.Domain.Entities;
using Identity.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Result<Guid>> RegisterAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return Result<Guid>.Failure(errors);
            }

            return Result<Guid>.Success(user.Id);
        }

        public async Task<Result> UpdateAccountAsync(ApplicationUser updateModel)
        {
            var user = await _userManager.FindByIdAsync(updateModel.Id.ToString());
            if (user == null) return Result.Failure($"User {updateModel.Id} not found");

            user.UserName = updateModel.UserName;
            user.Email = updateModel.Email;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        public async Task<Result> PatchAccountAsync(Guid id, ApplicationUser patchModel)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return Result.Failure($"User {id} not found");

            if (!string.IsNullOrEmpty(patchModel.UserName)) user.UserName = patchModel.UserName;
            if (!string.IsNullOrEmpty(patchModel.Email)) user.Email = patchModel.Email;

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        public async Task<Result> DeleteAccountAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return Result.Failure($"User {id} not found");

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(string.Join("; ", result.Errors.Select(e => e.Description)));
        }

        public async Task<Result> ChangePasswordAsync(Guid userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return Result.Failure($"User {userId} not found");

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(string.Join("; ", result.Errors.Select(e => e.Description)));
        }
    }
}
