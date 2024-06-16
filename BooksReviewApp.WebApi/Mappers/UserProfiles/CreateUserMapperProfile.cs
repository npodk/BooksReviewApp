using AutoMapper;
using BooksReviewApp.WebApi.Dtos.User;
using BooksReviewApp.Domain.Core.Entities;

namespace BooksReviewApp.WebApi.Mappers.UserProfiles
{
    public class CreateUserMapperProfile : Profile
    {
        public CreateUserMapperProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
