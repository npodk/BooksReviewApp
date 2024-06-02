namespace BooksReviewApp.WebApi.Dtos.Genre
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public string[] BookTitles { get; set; }
    }
}
