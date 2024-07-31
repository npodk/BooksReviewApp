using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;

namespace BooksReviewApp.WebApi.Converters.UserConverters
{
    public class FavoriteBooksConverter : IValueConverter<IEnumerable<Favorite>, string[]>
    {
        public string[] Convert(IEnumerable<Favorite> sourceMember, ResolutionContext context)
        {
            return sourceMember.Select(f => f.Book.Title).ToArray();
        }
    }
}
