namespace BooksReviewApp.WebApi.Dtos.User
{
    public abstract class BaseUserDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
