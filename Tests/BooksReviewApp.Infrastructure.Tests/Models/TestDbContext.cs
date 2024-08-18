using Microsoft.EntityFrameworkCore;

namespace BooksReviewApp.Infrastructure.Tests.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
