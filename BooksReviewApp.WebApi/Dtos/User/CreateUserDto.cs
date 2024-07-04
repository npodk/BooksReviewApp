namespace BooksReviewApp.WebApi.Dtos.User
{
    public class CreateUserDto : BaseUserDto
    {
        public new string Username { get; set; } = default!;
        public new string Email { get; set; } = default!;
        public new string Password { get; set; } = default!;
    }
}
