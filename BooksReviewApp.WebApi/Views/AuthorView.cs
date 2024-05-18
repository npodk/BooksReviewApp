namespace BooksReviewApp.WebApi.Views
{
    public class AuthorView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public ICollection<string> BookNames { get; set; } = new List<string>();
    }
}
