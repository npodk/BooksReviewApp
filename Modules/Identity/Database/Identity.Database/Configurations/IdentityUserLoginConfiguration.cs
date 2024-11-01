using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Services.AspNet.Identity.Constants;

namespace BooksReviewApp.Services.AspNet.Identity.Configurations
{
    public class IdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
        {
            builder.ToTable(IdentityTableNames.UserLogin, SchemaTypes.Identity);
        }
    }
}
