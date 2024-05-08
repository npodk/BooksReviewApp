using BooksReviewApp.Domain.Core.Entities;

namespace BooksReviewApp.Domain.Core.Constants
{
    public static class Constants
    {
        public static class UserEntity
        {
            public static readonly User DefaultUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Email = "admin@test.com",
                Password = "Pass123"
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
        }
    }
}
