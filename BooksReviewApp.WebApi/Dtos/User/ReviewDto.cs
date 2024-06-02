namespace BooksReviewApp.WebApi.Dtos.User
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string BookTitle { get; set; }
    }
}
