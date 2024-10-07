namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class UpdateBookDto : CreateBookDto
    {
        public Guid Id { get; set; }
    }
}
