using BooksReviewApp.Database.Extensions;
using BooksReviewApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static BooksReviewApp.Domain.Constants;

namespace BooksReviewApp.Database.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable(TableNames.Review, SchemaTypes.Dbo, t =>
            {
                t.HasCheckConstraint("CK_Reviews_Rating", "\"Rating\" BETWEEN 1 AND 5");
            });

            builder.HasIdKey();

            builder.Property(r => r.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(r => r.Rating)
                .IsRequired();
        }
    }
}
