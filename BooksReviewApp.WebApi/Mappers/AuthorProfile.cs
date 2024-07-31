using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.WebApi.Dtos.Author;

namespace BooksReviewApp.WebApi.Mappers
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorDto, Author>();

            CreateMap<UpdateAuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Author, ReadAuthorDto>()
                .ForMember(dest => dest.BookTitles, opt => opt.MapFrom(src => src.Books));
        }
    }
}
