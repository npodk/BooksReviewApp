using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Services.AspNet.Identity.Constants;

namespace BooksReviewApp.Services.AspNet.Identity.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable(IdentityTableNames.ApplicationUser, SchemaTypes.Identity);
            
            var user = Account.DefaultUser;
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, Account.DefaultPassword);

            builder.HasData(user);
        }
    }
}
