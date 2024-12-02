namespace Identity.WebApi.Integration.Models
{
    public class PatchUserModel
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }
    }
}
