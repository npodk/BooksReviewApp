using BooksReviewApp.Database;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.Services.Database;
using BooksReviewApp.Services.EF.Interfaces;

namespace BooksReviewApp.Services.EF
{
    public class GenreDbService : BaseDbCrudService<Genre, LibraryDbContext>, IGenreDbService
    {
        public GenreDbService(LibraryDbContext context) : base(context)
        {
        }
    }
}
