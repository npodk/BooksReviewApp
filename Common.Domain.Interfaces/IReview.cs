namespace Common.Domain.Interfaces
{
    public interface IReview
    {
        int Id { get; }
        string Text { get; }
        int Rating { get; } 
                  
        int BookId { get; }
        IBook Book { get; }

        int UserId { get; }
        IUser User { get; }
    }
}
