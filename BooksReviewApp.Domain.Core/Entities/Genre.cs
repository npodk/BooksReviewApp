using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        // many-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
