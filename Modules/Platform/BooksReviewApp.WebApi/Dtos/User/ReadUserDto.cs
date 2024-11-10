namespace BooksReviewApp.WebApi.Dtos.User
{
    public class ReadUserDto
    {
        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string[] FavoriteBooks { get; set; }

        public ReviewDto[] Reviews { get; set; }
    }
}
