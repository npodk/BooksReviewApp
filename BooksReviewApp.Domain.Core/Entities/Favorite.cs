using System.ComponentModel.DataAnnotations.Schema;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Favorite
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }


        // many-to-one relationship
        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
