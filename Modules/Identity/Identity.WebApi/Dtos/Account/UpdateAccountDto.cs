namespace Identity.WebApi.Dtos.Account
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
