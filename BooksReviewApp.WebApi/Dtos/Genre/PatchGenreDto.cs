namespace BooksReviewApp.WebApi.Dtos.Genre
{
    public class PatchGenreDto : BaseGenreDto
    {
        public Guid Id { get; set; }

        public new string? Name { get; set; }

        public new string? Description { get; set; }
    }
}
