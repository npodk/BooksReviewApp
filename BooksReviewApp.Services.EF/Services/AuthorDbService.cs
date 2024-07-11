using BooksReviewApp.Database;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.Services.Database;
using BooksReviewApp.Services.EF.Interfaces;

namespace BooksReviewApp.Services.EF.Services
{
    public class AuthorDbService : BaseDbCrudService<Author, LibraryDbContext>, IAuthorDbService
    {
        public AuthorDbService(LibraryDbContext context) : base(context)
        {
        }
    }
}
