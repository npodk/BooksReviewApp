namespace BooksReviewApp.Services.Identity.AspNet.Models
{
    public class IdentitySettings
    {
        public PasswordOptions Password { get; set; }

        public LockoutOptions Lockout { get; set; }

        public UserOptions User { get; set; }
    }
}
