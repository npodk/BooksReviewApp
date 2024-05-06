using BooksReviewApp.Domain.Core.Constants;
using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BooksReviewApp.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnType("uuid");

            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasMany(u => u.Favorites)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Constants.UserEntity.DefaultUser);
        }
    }
}
