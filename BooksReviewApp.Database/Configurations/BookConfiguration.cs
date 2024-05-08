using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Domain.Core.Constants.Constants;

namespace BooksReviewApp.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(TableNames.Book, SchemaTypes.Dbo);

            builder.HasIdKey();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PublishingYear)
                .IsRequired();

            builder.Property(b => b.WritingYear)
                .IsRequired();

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(17);

            builder.Property(b => b.Description)
                .HasMaxLength(500);

            builder.HasMany(b => b.Reviews)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Favorites)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity<BookGenre>(
                j => j.HasOne(bg => bg.Genre).WithMany(g => g.BookGenres),
                j => j.HasOne(bg => bg.Book).WithMany(b => b.BookGenres),
                j =>
                {
                    j.HasKey(bg => new { bg.BookId, bg.GenreId });
                });
        }
    }
}
