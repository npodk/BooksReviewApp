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
    }
}
