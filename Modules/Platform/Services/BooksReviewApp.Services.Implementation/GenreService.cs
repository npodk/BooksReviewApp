using BooksReviewApp.Database;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.Services.Contracts.Interfaces;
using BooksReviewApp.Services.EF;

namespace BooksReviewApp.Services.Implementation
{
    public class GenreService : BaseDbCrudService<Genre, LibraryDbContext>, IGenreService
    {
        public GenreService(LibraryDbContext context) : base(context)
        {
        }
    }
}
