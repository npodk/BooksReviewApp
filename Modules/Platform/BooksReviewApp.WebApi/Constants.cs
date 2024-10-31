namespace BooksReviewApp.WebApi
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

        public static class BookValidation
        {
            public const int MaxTitleLength = 100;
            public const int MaxPublisherLength = 100;
            public const int MaxDescriptionLength = 500;
            public const int MinPublishingYear = 1000;
            public const int MinWritingYear = 1000;
            public const string ISBNPattern = @"^(97(8|9))?\d{9}(\d|X)$|^(97(8|9))?\d{1,5}[\s-]?\d{1,7}[\s-]?\d{1,7}[\s-]?\d{1}[\s-]?(\d|X)$";
        }

        public static class GenreValidation
        {
            public const int MaxNameLength = 75;
            public const int MaxDescriptionLength = 500;
        }

        public static class ReviewValidation
        {
            public const int MaxTextLength = 1000;
            public const int MinRating = 1;
            public const int MaxRating = 10;
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
