namespace BooksReviewApp.WebApi.Dtos.Favorite
{
    public class BaseFavoriteDto
    {
        public DateTime DateAdded { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
