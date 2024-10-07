namespace BooksReviewApp.WebApi.Dtos.User
{
    public class ReadUserDto : BaseUserDto
    {
        public Guid Id { get; set; }

        public string[] FavoriteBooks { get; set; }

        public ReviewDto[] Reviews { get; set; }
    }
}
