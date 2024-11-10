namespace BooksReviewApp.WebApi.Dtos.Review
{
    public class ReadReviewDto : BaseReviewDto
    {
        public Guid Id { get; set; }

        public string BookTitle { get; set; }

        public string Username { get; set; }
    }
}
