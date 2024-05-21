namespace BooksReviewApp.WebApi.Dtos
{
    public class FavoriteDto
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
    }
}
