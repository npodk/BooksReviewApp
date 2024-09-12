using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.Book;

namespace BooksReviewApp.WebApi.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();

            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<PatchBookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Book, ReadBookDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ForMember(dest => dest.Favorites, opt => opt.MapFrom(src => src.Favorites))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres));

            CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.AuthorSurname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

            CreateMap<Favorite, FavoriteDto>();

            CreateMap<Genre, GenreDto>();
        }
    }
}
