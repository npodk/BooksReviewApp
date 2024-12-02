using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.User;
using Identity.WebApi.Integration.Models;

namespace BooksReviewApp.WebApi.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>();

            CreateMap<PatchUserDto, User>();

            CreateMap<CreateUserDto, CreateUserModel>();

            CreateMap<UpdateUserDto, UpdateUserModel>();

            CreateMap<PatchUserDto, PatchUserModel>();

            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.FavoriteBooks, opt => opt.MapFrom(src => src.Favorites))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));
        }
    }
}
