using BooksReviewApp.Core.Domain.Interfaces;
using BooksReviewApp.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Genre : IModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        // many-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();

        // navigation property for the join table
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
