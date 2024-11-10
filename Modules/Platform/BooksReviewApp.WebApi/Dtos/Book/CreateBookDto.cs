namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class CreateBookDto : BaseBookDto
    {
        public Guid[] GenreIds { get; set; }
    }
}
