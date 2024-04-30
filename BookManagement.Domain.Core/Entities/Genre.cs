using Common.Domain.Interfaces;

namespace BookManagement.Domain.Core.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // many-to-many relationship
        public ICollection<IBook> Books { get; set; } = new List<IBook>();
    }
}
