namespace BooksReviewApp.WebApi.Dtos.Favorite
{
    public abstract class BaseFavoriteDto
    {
        public DateTime DateAdded { get; set; }

        public Guid BookId { get; set; }
    }
}
