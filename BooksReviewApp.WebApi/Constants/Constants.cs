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
            public const string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        }

        public static class AuthorValidation
        {
            public const int MaxNameLength = 50;
            public const int MaxSurnameLength = 50;
            public const int MaxBiographyLength = 1000;
        }

        public static class ExceptionHandling
        {
            public const string DefaultErrorMessage = "An unexpected error occurred.";
        }

        public static class CacheKeys
        {
            public const string ValidationMessagesLocalized = "ValidationMessages";
        }
    }
}
