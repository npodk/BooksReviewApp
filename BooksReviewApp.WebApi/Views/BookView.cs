namespace BooksReviewApp.WebApi.Views
{
    public class BookView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublishingYear { get; set; }
        public int WritingYear { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }

        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }

        public ICollection<ReviewView> Reviews { get; set; } = new List<ReviewView>();

        public ICollection<string> UsersLiked { get; set; } = new List<string>();

        public ICollection<string> GenreNames { get; set; } = new List<string>();
    }
}
