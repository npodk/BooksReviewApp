using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Services.AspNet.Identity.Constants;

namespace BooksReviewApp.Services.AspNet.Identity.Configurations
{
    public class IdentityUserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            builder.ToTable(IdentityTableNames.UserClaim, SchemaTypes.Identity);
        }
    }
}
