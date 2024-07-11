using BooksReviewApp.Database;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.Services.Database;
using BooksReviewApp.Services.EF.Interfaces;

namespace BooksReviewApp.Services.EF.Services
{
    public class UserDbService : BaseDbCrudService<User, LibraryDbContext>, IUserDbService
    {
        public UserDbService(LibraryDbContext context) : base(context)
        {
        }
    }
}
