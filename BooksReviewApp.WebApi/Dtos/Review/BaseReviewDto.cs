namespace BooksReviewApp.WebApi.Dtos.Review
{
    public class BaseReviewDto
    {
        public string Text { get; set; }
        public int Rating { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
