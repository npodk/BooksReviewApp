namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class PatchBookDto : BaseBookDto
    {
        public Guid Id { get; set; }

        public new string? Title { get; set; }

        public new string? Publisher { get; set; }

        public new int? PublishingYear { get; set; }

        public new int? WritingYear { get; set; }

        public new string? ISBN { get; set; }

        public new string? Description { get; set; }

        public new Guid? AuthorId { get; set; }
    }
}
