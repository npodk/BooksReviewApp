namespace BooksReviewApp.Domain.Core.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }

        // one-to-many relationship
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
