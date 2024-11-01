using BooksReviewApp.Services.Identity.AspNet.Helpers;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Services.AspNet.Identity.Constants;

namespace BooksReviewApp.Services.AspNet.Identity.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(IdentityTableNames.Permission, SchemaTypes.Identity);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId);

            var permissions = PermissionHelper.GenerateAllPermissions()
                .Select(p => new Permission { Id = Guid.NewGuid(), Name = p })
                .ToList();

            builder.HasData(permissions);
        }
    }
}
