namespace BooksReviewApp.WebApi.Dtos.Author
{
    public class ReadAuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public string[] BookTitles { get; set; }
    }
}
