using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Converters.UserConverters
{
    public class ReviewsConverter : IValueConverter<IEnumerable<Review>, ReviewDto[]>
    {
        public ReviewDto[] Convert(IEnumerable<Review> source, ResolutionContext context)
        {
            return source.Select(r => new ReviewDto
            {
                Id = r.Id,
                Text = r.Text,
                Rating = r.Rating,
                BookTitle = r.Book.Title
            }).ToArray();
        }
    }
}
