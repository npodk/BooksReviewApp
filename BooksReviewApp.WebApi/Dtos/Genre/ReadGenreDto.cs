namespace BooksReviewApp.WebApi.Dtos.Genre
{
    public class ReadGenreDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public BookDto[] Books { get; set; }
    }
}
