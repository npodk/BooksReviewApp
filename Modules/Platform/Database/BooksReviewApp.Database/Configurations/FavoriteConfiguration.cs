using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Domain.Constants;

namespace BooksReviewApp.Database.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable(TableNames.Favorite, SchemaTypes.Dbo);

            builder.HasIdKey();

            builder.Property(f => f.DateAdded)
                .IsRequired();
        }
    }
}
