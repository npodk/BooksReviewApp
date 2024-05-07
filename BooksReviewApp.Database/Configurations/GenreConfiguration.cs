using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksReviewApp.Database.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres", "dbo");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnType("uuid");

            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

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
