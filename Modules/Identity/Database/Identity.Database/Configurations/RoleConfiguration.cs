using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Services.AspNet.Identity.Constants;

namespace BooksReviewApp.Services.AspNet.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(IdentityTableNames.Role, SchemaTypes.Identity);

            builder.HasMany(r => r.RolePermissions)
               .WithOne(rp => rp.Role)
               .HasForeignKey(rp => rp.RoleId);

            builder.HasData(Account.DefaultRole);
        }
    }
}
