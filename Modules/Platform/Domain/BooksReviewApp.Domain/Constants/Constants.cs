using BooksReviewApp.Domain.Entities;

namespace BooksReviewApp.Domain.Constants
{
    public static class Constants
    {
        public static class UserEntity
        {
            public static readonly User DefaultUser = new User
            {
                Id = new Guid("18ba8366-df77-441f-9154-1c897892c449"),
                Username = "admin",
                Email = "admin@example.com"
            };
        }

        public static class TableNames
        {
            public const string Book = "Books";
            public const string Author = "Authors";
            public const string BookGenre = "BookGenres";
            public const string Favorite = "Favorites";
            public const string Genre = "Genres";
            public const string Review = "Reviews";
            public const string User = "Users";
        }

        public static class SchemaTypes
        {
            public const string Dbo = "dbo";
            public const string Identity = "identity";
        }
    }
}
