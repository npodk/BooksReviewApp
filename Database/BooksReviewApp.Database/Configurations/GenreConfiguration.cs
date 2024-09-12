using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Domain.Constants.Constants;

namespace BooksReviewApp.Database.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable(TableNames.Genre, SchemaTypes.Dbo);

            builder.HasIdKey();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasIndex(g => g.Name).IsUnique();

            builder.Property(g => g.Description)
                .HasMaxLength(500);

            builder.HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .UsingEntity<BookGenre>(
                j => j.HasOne(bg => bg.Book).WithMany(b => b.BookGenres),
                j => j.HasOne(bg => bg.Genre).WithMany(g => g.BookGenres),
                j =>
                {
                    j.HasKey(bg => new { bg.BookId, bg.GenreId });
                });
        }
    }
}
