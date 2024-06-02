namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class ReadBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
        public int WritingYear { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }

        public Guid AuthorId { get; set; }
        public AuthorDto Author { get; set; }

        public ReviewDto[] Reviews { get; set; }
        public string[] UsersLiked { get; set; }
        public string[] GenreNames { get; set; }
    }
}
