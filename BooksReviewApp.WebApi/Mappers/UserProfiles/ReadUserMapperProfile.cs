using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.WebApi.Converters.User;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Mappers.UserProfiles
{
    public class ReadUserMapperProfile : Profile
    {
        public ReadUserMapperProfile()
        {
            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.FavoriteBooks, opt => opt.ConvertUsing(new FavoriteBooksConverter(), src => src.Favorites))
                .ForMember(dest => dest.Reviews, opt => opt.ConvertUsing(new ReviewsConverter(), src => src.Reviews));
        }
    }
}
