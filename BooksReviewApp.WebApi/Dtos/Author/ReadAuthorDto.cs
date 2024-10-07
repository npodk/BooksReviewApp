namespace BooksReviewApp.WebApi.Dtos.Author
{
    public class ReadAuthorDto : BaseAuthorDto
    {
        public Guid Id { get; set; }

        public string[] BookTitles { get; set; }
    }
}
