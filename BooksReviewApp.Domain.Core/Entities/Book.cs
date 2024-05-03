namespace BooksReviewApp.Domain.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
        public int WritingYear { get; set; }
        public string ISBN { get; set; }
        public string? Description { get; set; }

        // many-to-one relationship
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        // one-to-many relationship
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        // many-to-many relationship
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        // navigation property for the join table
        public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
    }
}
