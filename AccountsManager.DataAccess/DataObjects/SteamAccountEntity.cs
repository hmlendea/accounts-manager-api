namespace AccountsManager.DataAccess.DataObjects
{
    public sealed class SteamAccountEntity : IAccountEntity
    {
        const char Separator = ',';

        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Username}{Separator}{Password}{Separator}{EmailAddress}{Separator}{Country}";
        }

        public static SteamAccountEntity FromString(string value)
        {
            string[] fields = value.Split(Separator);

            SteamAccountEntity steamAccount = new SteamAccountEntity();
            steamAccount.Username = fields[0];
            steamAccount.Password = fields[1];
            steamAccount.EmailAddress = fields[2];
            steamAccount.Country = fields[3];

            return steamAccount;
        }
    }
}