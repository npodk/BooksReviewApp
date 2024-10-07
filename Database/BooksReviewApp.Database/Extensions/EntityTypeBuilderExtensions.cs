using BooksReviewApp.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksReviewApp.Database.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<T> HasIdKey<T>(this EntityTypeBuilder<T> builder) where T : class, IModel
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("uuid");

            return builder;
        }

        public static EntityTypeBuilder<T> HasSoftDelete<T>(this EntityTypeBuilder<T> builder) where T : class, IAuditable
        {
            builder.Property(e => e.IsDeleted).HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            return builder;
        }
    }
}
