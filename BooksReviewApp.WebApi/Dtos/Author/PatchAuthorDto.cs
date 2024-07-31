namespace BooksReviewApp.WebApi.Dtos.Author
{
    public class PatchAuthorDto : BaseAuthorDto
    {
        public Guid Id { get; set; }

        public new string? Name { get; set; }

        public new string? Surname { get; set; }

        public new string? Biography { get; set; }
    }
}
