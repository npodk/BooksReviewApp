using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.Book;

namespace BooksReviewApp.WebApi.Converters.BookConverters
{
    public class GenreDtoConverter : IValueConverter<ICollection<BookGenre>, IEnumerable<GenreDto>>
    {
        public IEnumerable<GenreDto> Convert(ICollection<BookGenre> sourceMember, ResolutionContext context)
        {
            return sourceMember.Select(bg => new GenreDto
            {
                Id = bg.Genre.Id,
                Name = bg.Genre.Name
            });
        }
    }
}
