using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Rating { get; set; }

        // many-to-one relationship
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
