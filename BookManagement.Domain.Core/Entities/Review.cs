using Common.Domain.Interfaces;

namespace BookManagement.Domain.Core.Entities
{
    public class Review : IReview
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        // many-to-one relationship
        public int BookId { get; set; }
        public IBook Book { get; set; }

        public int UserId { get; set; }
        public IUser User { get; set; }
    }
}
