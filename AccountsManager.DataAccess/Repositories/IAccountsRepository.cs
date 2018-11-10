using System.Collections.Generic;

using AccountsManager.DataAccess.DataObjects;

namespace AccountsManager.DataAccess.Repositories
{
    public interface IAccountsRepository<T> where T : IAccountEntity
    {
        void Add(T entity);

        IEnumerable<T> GetAll();

        T Get(string username);

        void Update(string username, T entity);

        void Remove(string username);
    }
}
