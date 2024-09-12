using AutoMapper;
using BooksReviewApp.Domain.Entities;
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

            CreateMap<PatchAuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Author, ReadAuthorDto>()
                .ForMember(dest => dest.BookTitles, opt => opt.MapFrom(src => src.Books));
        }
    }
}
