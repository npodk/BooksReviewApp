namespace BooksReviewApp.WebApi.Dtos.Review
{
    public class UpdateReviewDto : CreateReviewDto
    {
        public Guid Id { get; set; }
    }
}
