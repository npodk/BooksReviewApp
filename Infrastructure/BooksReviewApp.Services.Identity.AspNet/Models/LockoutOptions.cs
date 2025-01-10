namespace BooksReviewApp.Services.Identity.AspNet.Models
{
    public class LockoutOptions
    {
        public double DefaultLockoutTimeSpanInMinutes { get; set; }

        public int MaxFailedAccessAttempts { get; set; }

        public bool AllowedForNewUsers { get; set; }
    }
}
