using AutoMapper;
using BooksReviewApp.Domain.Core.Entities;
using BooksReviewApp.WebApi.Dtos.Book;

namespace BooksReviewApp.WebApi.Mappers.BookProfiles
{
    public class BaseBookMapperProfile : Profile
    {
        public BaseBookMapperProfile()
        {
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Genres, opt => opt.Ignore())
                .AfterMap((dto, book, context) =>
                {
                    if (dto.GenreIds != null)
                    {
                        var genres = context.Items["Genres"] as ICollection<Genre>;
                        if (genres != null)
                        {
                            book.Genres = genres.Where(g => dto.GenreIds.Contains(g.Id)).ToList();
                        }
                    }
                });
        }
    }
}
