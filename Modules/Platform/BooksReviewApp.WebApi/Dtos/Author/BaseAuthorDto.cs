namespace BooksReviewApp.WebApi.Dtos.Author
{
    public abstract class BaseAuthorDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Biography { get; set; }
    }
}
