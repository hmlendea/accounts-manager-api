namespace AccountsManager.API.Models
{
    public sealed class SteamAccount
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string Country { get; set; }
    }
}
