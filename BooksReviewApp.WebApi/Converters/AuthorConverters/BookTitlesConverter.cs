using AutoMapper;
using BooksReviewApp.Domain.Entities;

namespace BooksReviewApp.WebApi.Converters.AuthorConverters
{
    public class BookTitlesConverter : IValueConverter<Author, IEnumerable<string>>
    {
        public IEnumerable<string> Convert(Author sourceMember, ResolutionContext context)
        {
            return sourceMember.Books.Select(b => b.Title);
        }
    }
}
