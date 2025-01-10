using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Domain.Constants;

namespace BooksReviewApp.Database.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(TableNames.Author, SchemaTypes.Dbo);

            builder.HasIdKey();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Biography)
                .HasMaxLength(1000);

            builder.HasMany(b => b.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
