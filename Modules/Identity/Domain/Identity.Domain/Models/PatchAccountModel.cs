namespace Identity.Domain.Models
{
    public class PatchAccountModel
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }
    }
}
