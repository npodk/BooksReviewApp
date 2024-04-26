using System.ComponentModel.DataAnnotations;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // one-to-many relationship
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
