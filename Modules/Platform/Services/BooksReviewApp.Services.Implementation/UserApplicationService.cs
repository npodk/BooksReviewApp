using BooksReviewApp.Core.Domain;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using Identity.WebApi.Integration;
using Identity.WebApi.Integration.Models;

namespace BooksReviewApp.Services.Implementation
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserService _userService;
        private readonly IIntegrationService _integrationService;

        public UserApplicationService(IUserService userService, IIntegrationService integrationService)
        {
            _userService = userService;
            _integrationService = integrationService;
        }

        public async Task<IEnumerable<User?>> GetAllUsersAsync()
        {
            return await _userService.GetAllAsync();
        }

        public async Task<User?> GetUserById(Guid userId)
        {
            return await _userService.GetByIdAsync(userId);
        }

        public async Task<Result<Guid>> CreateUserAsync(User user, CreateUserModel userModel)
        {
            var identityUserId = await _integrationService.CreateUserAsync(userModel);
            user.ApplicationUserId = identityUserId;

            try
            {
                var createdUser = await _userService.CreateAsync(user);
                return Result<Guid>.Success(createdUser.Id);
            }
            catch (Exception ex)
            {
                await _integrationService.DeleteUserAsync(user.ApplicationUserId);
                return Result<Guid>.Failure(ex.Message);
            }
        }

        public async Task<Result<User?>> UpdateUserAsync(Guid id, User updatedUser, UpdateUserModel updatedUserModel)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return Result<User?>.Failure("User not found");

            updatedUser.Id = id;
            updatedUser.ApplicationUserId = user.ApplicationUserId;
            updatedUserModel.Id = user.ApplicationUserId;

            var result = await _userService.UpdateAsync(updatedUser);
            try
            {
                await _integrationService.UpdateUserAsync(updatedUserModel);
                return Result<User?>.Success(result);
            }
            catch (Exception ex)
            {
                await _userService.UpdateAsync(user);
                return Result<User?>.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteUserAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return Result.Failure("User not found");
            
            await _userService.DeleteAsync(id);
            try
            {
                await _integrationService.DeleteUserAsync(user.ApplicationUserId);
                return Result.Success();
            }
            catch (Exception ex)
            {
                await _userService.CreateWithoutIdAsync(user);
                return Result.Failure(ex.Message);
            }
        }
    }
}
