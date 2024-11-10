namespace BooksReviewApp.WebApi.Dtos.Book
{
    public class ReadBookDto : BaseBookDto
    {
        public Guid Id { get; set; }

        public AuthorDto Author { get; set; }

        public ReviewDto[] Reviews { get; set; }

        public FavoriteDto[] Favorites { get; set; }

        public GenreDto[] Genres { get; set; }
    }
}
