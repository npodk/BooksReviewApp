namespace Common.Domain.Interfaces
{
    public interface IFavorite
    {
        int Id { get; }
        DateTime DateAdded { get; }

        int UserId { get; }
        IUser User { get; }

        int BookId { get; }
        IBook Book { get; }
    }
}
