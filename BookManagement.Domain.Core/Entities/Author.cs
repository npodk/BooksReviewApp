using Common.Domain.Interfaces;

namespace BookManagement.Domain.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }

        // one-to-many relationship
        public ICollection<IBook> Books { get; set; } = new List<IBook>();
    }
}
