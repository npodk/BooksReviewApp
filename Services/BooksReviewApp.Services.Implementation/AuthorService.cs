using BooksReviewApp.Database;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.Services.EF;
using BooksReviewApp.Domain.Entities;

namespace BooksReviewApp.Services.Implementation
{
    public class AuthorService : BaseDbCrudService<Author, LibraryDbContext>, IAuthorService
    {
        public AuthorService(LibraryDbContext context) : base(context)
        {
        }
    }
}
