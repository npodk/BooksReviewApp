using BooksReviewApp.Domain.Core.Constants;
using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksReviewApp.Database.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Biography)
                .HasMaxLength(1000);

            builder.HasMany(b => b.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
            Enumerable.Range(0, AuthorConstants.ExamplesNumber)
                .Select(i => new Author
                {
                    Id = i + 1,
                    Name = AuthorConstants.DefaultNames[i],
                    Surname = AuthorConstants.DefaultSurnames[i],
                    Biography = AuthorConstants.DefaultBiographies[i]
                }));
        }
    }
}
