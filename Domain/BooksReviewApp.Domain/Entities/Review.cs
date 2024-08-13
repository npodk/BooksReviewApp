using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Domain.Core.Entities
{
    public class Review : IModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        // many-to-one relationship
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
