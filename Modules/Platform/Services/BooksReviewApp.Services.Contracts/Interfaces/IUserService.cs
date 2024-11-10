using BooksReviewApp.Core.Services.Interfaces;
using BooksReviewApp.Domain.Entities;

namespace BooksReviewApp.Services.Contracts.Interfaces
{
    public interface IUserService : ICrudService<User>
    {
        Task<User?> GetByApplicationUserIdAsync(Guid applicationUserId);
    }
}
