namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string UserName { get; set; }
    }
}
