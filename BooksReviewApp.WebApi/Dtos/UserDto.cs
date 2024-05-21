namespace BooksReviewApp.WebApi.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<string> FavoriteBooks { get; set; } = new List<string>();

        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }
}
