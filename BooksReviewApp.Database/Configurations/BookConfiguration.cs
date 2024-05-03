using BooksReviewApp.Domain.Core.Constants;
using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksReviewApp.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books", "dbo");

            builder.HasKey(b => b.Id);

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
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Favorites)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity<BookGenre>(
                j => j.HasOne(bg => bg.Genre).WithMany(g => g.BookGenres),
                j => j.HasOne(bg => bg.Book).WithMany(b => b.BookGenres),
                j =>
                {
                    j.HasKey(bg => new { bg.BookId, bg.GenreId });
                });

        builder.HasData(
            Enumerable.Range(0, BookConstants.ExamplesNumber)
                .Select(i => new Book
                {
                    Id = i + 1,
                    Title = BookConstants.DefaultTitles[i],
                    Publisher = BookConstants.DefaultPublishers[i],
                    WritingYear = BookConstants.DefaultWritingYears[i],
                    PublishingYear = BookConstants.DefaultPublishingYears[i],
                    ISBN = BookConstants.DefaultISBNs[i],
                    Description = BookConstants.DefaultDescriptions[i],
                    AuthorId = i + 1,
                }));
        }
    }
}
