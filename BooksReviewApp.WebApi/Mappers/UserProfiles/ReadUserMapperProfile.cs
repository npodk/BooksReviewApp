using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Mappers.UserProfiles
{
    public class ReadUserMapperProfile : Profile
    {
        public ReadUserMapperProfile()
        {
            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.FavoriteBooks, opt => opt.MapFrom(src => src.Favorites.Select(f => f.Book.Title).ToArray()))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating,
                    BookTitle = r.Book.Title
                }).ToArray()));
        }
    }
}
