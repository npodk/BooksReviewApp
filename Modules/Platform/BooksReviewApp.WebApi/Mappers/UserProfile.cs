using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.User;

namespace BooksReviewApp.WebApi.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.FavoriteBooks, opt => opt.MapFrom(src => src.Favorites))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));
        }
    }
}
