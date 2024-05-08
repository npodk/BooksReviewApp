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

        public static EntityTypeBuilder<T> IsSoftDetele<T>(this EntityTypeBuilder<T> builder) where T : class, IAuditable
        {
            builder.Property<bool>("IsDeleted").HasDefaultValue(false);
            builder.HasQueryFilter(e => !EF.Property<bool>(e, "IsDeleted"));

            return builder;
        }
    }
}
