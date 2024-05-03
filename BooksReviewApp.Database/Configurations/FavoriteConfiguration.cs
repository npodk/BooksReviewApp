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

            builder.HasData(
            Enumerable.Range(0, BookConstants.ExamplesNumber)
                .Select(i => new Favorite
                {
                    Id = i + 1,
                    DateAdded = DateTime.UtcNow,
                    BookId = i + 1,
                    UserId = i + 1
                }));
        }
    }
}
