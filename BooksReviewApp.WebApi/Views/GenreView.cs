namespace BooksReviewApp.WebApi.Views
{
    public class GenreView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<string> BookTitles { get; set; } = new List<string>();
    }
}
