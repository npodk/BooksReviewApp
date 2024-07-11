namespace BooksReviewApp.WebApi.Dtos.Author
{
    public class CreateAuthorDto : BaseAuthorDto
    {
        public new string? Name { get; set; } = default!;
        public new string? Surname { get; set; } = default!;
        public new string? Biography { get; set; } = default!;
    }
}
