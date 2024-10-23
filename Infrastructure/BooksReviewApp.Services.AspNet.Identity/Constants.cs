using BooksReviewApp.Services.AspNet.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace BooksReviewApp.Services.AspNet.Identity
{
    public static class Constants
    {
        public static class Account
        {
            public static readonly string DefaultPassword = "Admin987_";

            public static readonly ApplicationUser DefaultUser = new ApplicationUser
            {
                Id = new Guid("18ba8366-df77-441f-9154-1c897892c449"),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
            };

            public static readonly IdentityRole<Guid> DefaultRole = new IdentityRole<Guid>
            {
                Id = new Guid("a2c0f0d5-405e-4f3d-a77d-9a5efb6f7c41"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            public static readonly IdentityUserRole<Guid> DefaultUserRole = new IdentityUserRole<Guid>
            {
                UserId = DefaultUser.Id,
                RoleId = DefaultRole.Id
            };
        }

        public static class IdentityTableNames
        {
            public const string ApplicationUser = "AspNetUsers";
            public const string Role = "AspNetRoles";
            public const string UserClaim = "AspNetUserClaims";
            public const string UserRole = "AspNetUserRoles";
            public const string UserLogin = "AspNetUserLogins";
            public const string RoleClaim = "AspNetRoleClaims";
            public const string UserToken = "AspNetUserTokens";
        }
    }
}
