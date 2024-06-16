namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
        public int WritingYear { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }

        public Guid AuthorId { get; set; }
        public Guid[] GenreIds { get; set; }
    }
}
