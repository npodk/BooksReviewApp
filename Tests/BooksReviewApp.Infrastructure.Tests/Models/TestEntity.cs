using BooksReviewApp.Core.Domain.Interfaces;

namespace BooksReviewApp.Infrastructure.Tests.Models
{
    public class TestEntity : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
