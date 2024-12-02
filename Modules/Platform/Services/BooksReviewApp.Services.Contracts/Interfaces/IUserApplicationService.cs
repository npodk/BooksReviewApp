using BooksReviewApp.Core.Domain;
using BooksReviewApp.Domain.Entities;
using Identity.WebApi.Integration.Models;

namespace BooksReviewApp.Services.Contracts.Interfaces
{
    public interface IUserApplicationService
    {
        Task<IEnumerable<User?>> GetAllUsersAsync();

        Task<User?> GetUserById(Guid userId);

        Task<Result<Guid>> CreateUserAsync(User user, CreateUserModel userModel);

        Task<Result<User?>> UpdateUserAsync(Guid id, User updatedUser, UpdateUserModel updatedUserModel);

        Task<Result> DeleteUserAsync(Guid id);
    }
}
