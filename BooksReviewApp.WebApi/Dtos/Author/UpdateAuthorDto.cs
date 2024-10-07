namespace BooksReviewApp.WebApi.Dtos.Author
{
    public class UpdateAuthorDto : CreateAuthorDto
    {
        public Guid Id { get; set; }
    }
}
