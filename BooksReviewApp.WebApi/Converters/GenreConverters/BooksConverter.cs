using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.Genre;

namespace BooksReviewApp.WebApi.Converters.GenreConverters
{
    public class BooksConverter : IValueConverter<IEnumerable<Book>, BookDto[]>
    {
        public BookDto[] Convert(IEnumerable<Book> source, ResolutionContext context)
        {
            return source.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                AuthorFullName = $"{book.Author?.Name} {book.Author?.Surname}",
                ISBN = book.ISBN
            }).ToArray();
        }
    }
}
