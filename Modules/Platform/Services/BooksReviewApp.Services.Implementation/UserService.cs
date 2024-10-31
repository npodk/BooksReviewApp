using BooksReviewApp.Database;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.Services.EF;

namespace BooksReviewApp.Services.Implementation
{
    public class UserService : BaseDbCrudService<User, LibraryDbContext>, IUserService
    {
        public UserService(LibraryDbContext context) : base(context)
        {
        }
    }
}
