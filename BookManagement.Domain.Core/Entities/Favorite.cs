using Common.Domain.Interfaces;

namespace BookManagement.Domain.Core.Entities
{
    public class Favorite : IFavorite
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }


        // many-to-one relationship
        public int UserId { get; set; }
        public IUser User { get; set; }

        public int BookId { get; set; }
        public IBook Book { get; set; }
    }
}
