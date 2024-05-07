using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Favorite : IModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }


        // many-to-one relationship
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
