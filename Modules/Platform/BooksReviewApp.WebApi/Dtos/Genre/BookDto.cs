namespace BooksReviewApp.WebApi.Dtos.Genre
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? AuthorFullName { get; set; }

        public string ISBN { get; set; }
    }
}
