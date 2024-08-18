using AutoMapper;
using BooksReviewApp.Domain.Entities;
using BooksReviewApp.WebApi.Dtos.Genre;

namespace BooksReviewApp.WebApi.Mappers.GenreProfiles
{
    public class CreateGenreMapperProfile : Profile
    {
        public CreateGenreMapperProfile()
        {
            CreateMap<CreateGenreDto, Genre>();
        }
    }
}
