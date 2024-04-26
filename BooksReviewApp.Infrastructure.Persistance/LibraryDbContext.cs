using BooksReviewApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Infrastructure.Persistance
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(a => a.Reviews)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books);

            modelBuilder.Entity<User>()
                .HasMany(a => a.Reviews)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Favorites)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Favorites)
                .WithOne(f => f.Book)
                .HasForeignKey(f => f.BookId);
        }
    }
}
