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

            builder.Property(f => f.Id)
                .HasColumnType("uuid");

            builder.Property(f => f.DateAdded)
                .IsRequired();
        }
    }
}
