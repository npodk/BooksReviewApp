using BooksReviewApp.Domain.Core.Constants;
using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksReviewApp.Database.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorites", "dbo");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.DateAdded)
                .IsRequired();

            builder.HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Book)
                .WithMany(b => b.Favorites)
                .HasForeignKey(f => f.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            Enumerable.Range(0, BookConstants.ExamplesNumber)
                .Select(i => new Favorite
                {
                    Id = i + 1,
                    DateAdded = DateTime.Now,
                    BookId = i + 1,
                    UserId = i + 1
                }));
        }
    }
}
