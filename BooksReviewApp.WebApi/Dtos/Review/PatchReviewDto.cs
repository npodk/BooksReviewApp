namespace BooksReviewApp.WebApi.Dtos.Review
{
    public class PatchReviewDto : BaseReviewDto
    {
        public Guid Id { get; set; }

        public new string? Text { get; set; }

        public new int? Rating { get; set; }

        public Guid? BookId { get; set; }

        public Guid? UserId { get; set; }
    }
}
