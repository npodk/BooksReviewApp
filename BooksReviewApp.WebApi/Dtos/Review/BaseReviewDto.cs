namespace BooksReviewApp.WebApi.Dtos.Review
{
    public abstract class BaseReviewDto
    {
        public string Text { get; set; }

        public int Rating { get; set; }
    }
}
