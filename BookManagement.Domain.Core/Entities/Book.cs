using Common.Domain.Interfaces;

namespace BookManagement.Domain.Core.Entities
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string? Description { get; set; }

        // many-to-one relationship
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        // one-to-many relationship
        public ICollection<IReview> Reviews { get; set; } = new List<IReview>();

        public ICollection<IFavorite> Favorites { get; set; } = new List<IFavorite>();

        // many-to-many relationship
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}
