using System.Collections.Generic;
using System.IO;
using System.Linq;

using AccountsManager.Core.Configuration;
using AccountsManager.DataAccess.Exceptions;
using AccountsManager.DataAccess.DataObjects;

namespace AccountsManager.DataAccess.Repositories
{
    public sealed class SteamAccountsRepository : IAccountsRepository<SteamAccountEntity>
    {
        readonly AccountsManagerConfiguration configuration;

        public SteamAccountsRepository(AccountsManagerConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Add(SteamAccountEntity steamAccount)
        {
            IEnumerable<SteamAccountEntity> steamAccounts = GetAll();

            if (steamAccounts.Any(x => x.Username == steamAccount.Username))
            {
                throw new DuplicateEntityException(steamAccount.Username, nameof(SteamAccountEntity));
            }

            File.AppendText(steamAccount.ToString());
        }

        public IEnumerable<SteamAccountEntity> GetAll()
        {
            IEnumerable<string> lines = File.ReadAllLines(configuration.SteamAccountsStorePath);
            IList<SteamAccountEntity> steamAccounts = new List<SteamAccountEntity>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
    
                SteamAccountEntity steamAccount = SteamAccountEntity.FromString(line);
                steamAccounts.Add(steamAccount);
            }

            return steamAccounts;
        }    

        public SteamAccountEntity Get(string username)
        {
            IEnumerable<SteamAccountEntity> steamAccounts = GetAll();
            SteamAccountEntity steamAccount = steamAccounts.FirstOrDefault(x => x.Username == username);

            if (steamAccount == null)
            {
                throw new EntityNotFoundException(username, nameof(SteamAccountEntity));
            }

            return steamAccount;
        }

        public void Update(string username, SteamAccountEntity newSteamAccount)
        {
            IEnumerable<SteamAccountEntity> oldSteamAccounts = GetAll();

            if (oldSteamAccounts.All(x => x.Username != username))
            {
                throw new EntityNotFoundException(username, nameof(SteamAccountEntity));
            }

            IList<SteamAccountEntity> newSteamAccounts = oldSteamAccounts.Where(x => x.Username != username).ToList();
            newSteamAccounts.Add(newSteamAccount);

            IEnumerable<string> lines = newSteamAccounts.Select(x => x.ToString());
            File.WriteAllLines(configuration.SteamAccountsStorePath, lines);
        }

        public void Remove(string username)
        {
            IEnumerable<SteamAccountEntity> steamAccounts = GetAll();

            if (steamAccounts.All(x => x.Username != username))
            {
                throw new EntityNotFoundException(username, nameof(SteamAccountEntity));
            }

            steamAccounts = steamAccounts.Where(x => x.Username != username);

            IEnumerable<string> lines = steamAccounts.Select(x => x.ToString());
            File.WriteAllLines(configuration.SteamAccountsStorePath, lines);
        }
    }
}
