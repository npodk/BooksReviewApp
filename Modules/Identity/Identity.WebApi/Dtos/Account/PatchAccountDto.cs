namespace Identity.WebApi.Dtos.Account
{
    public class PatchAccountDto
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }
    }
}
