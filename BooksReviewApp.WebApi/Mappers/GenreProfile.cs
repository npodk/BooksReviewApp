using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.Genre;

namespace BooksReviewApp.WebApi.Mappers
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<CreateGenreDto, Genre>();

            CreateMap<UpdateGenreDto, Genre>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PatchGenreDto, Genre>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Genre, ReadGenreDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
        }
    }
}
