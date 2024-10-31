using BooksReviewApp.Database;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.Services.EF;

namespace BooksReviewApp.Services.Implementation
{
    public class BookService : BaseDbCrudService<Book, LibraryDbContext>, IBookService
    {
        public BookService(LibraryDbContext context) : base(context)
        {
        }
    }
}
