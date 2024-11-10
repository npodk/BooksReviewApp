namespace Identity.WebApi
{
    public static class Constants
    {
        public static class AccountValidation
        {
            public const int MaxUsernameLength = 50;
            public const int MaxEmailLength = 100;
            public const int MinPasswordLength = 8;
            public const int MaxPasswordLength = 128;
            public const string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        }
    }
}
