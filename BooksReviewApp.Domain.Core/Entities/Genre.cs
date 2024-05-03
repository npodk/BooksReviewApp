using BooksReviewApp.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public GenreNameEnum Name { get; set; }

        public string? Description { get; set; }

        // many-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();

        // navigation property for the join table
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
