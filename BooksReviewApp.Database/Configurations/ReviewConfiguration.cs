using BooksReviewApp.Domain.Core.Constants;
using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksReviewApp.Database.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews", "dbo", t =>
            {
                t.HasCheckConstraint("CK_Reviews_Rating", "\"Rating\" BETWEEN 1 AND 5");
            });

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            Enumerable.Range(0, ReviewConstants.ExamplesNumber)
                .Select(i => new Review
                {
                    Id = i + 1,
                    Text = ReviewConstants.DefaultTexts[i],
                    Rating = ReviewConstants.DefaultRatings[i],
                    BookId = i + 1,
                    UserId = i + 1,
                }));
        }
    }
}
