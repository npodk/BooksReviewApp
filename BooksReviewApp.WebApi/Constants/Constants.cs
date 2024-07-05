using Microsoft.AspNetCore.Http;

namespace BooksReviewApp.WebApi.Constants
{
    public static class Constants
    {
        public static class UserValidation
        {
            public const int MaxUsernameLength = 50;
            public const int MaxEmailLength = 100;
            public const int MinPasswordLength = 8;
            public const int MaxPasswordLength = 128;
        }

        public static class ExceptionHandling
        {
            public const string DefaultErrorMessage = "An unexpected error occurred.";
        }
    }
}
