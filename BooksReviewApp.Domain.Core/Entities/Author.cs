using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Biography { get; set; }

        // one-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
