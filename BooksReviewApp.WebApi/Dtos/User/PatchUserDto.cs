namespace BooksReviewApp.WebApi.Dtos.User
{
    public class PatchUserDto : BaseUserDto
    {
        public Guid Id { get; set; }

        public new string? Username { get; set; }

        public new string? Email { get; set; }

        public string? Password { get; set; }
    }

}
