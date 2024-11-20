namespace BooksReviewApp.WebApi.Dtos.User
{
    public class CreateUserDto : BaseUserDto
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
