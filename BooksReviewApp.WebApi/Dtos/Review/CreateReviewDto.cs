namespace BooksReviewApp.WebApi.Dtos.Review
{
    public class CreateReviewDto : BaseReviewDto
    {
        public Guid BookId { get; set; }

        public Guid UserId { get; set; }
    }
}
