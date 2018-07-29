using System.Collections.Generic;

namespace BankSystem
{
    /// <summary>
    /// Interface for repository of bank accounts.
    /// </summary>
    public interface IRepository
    {
        List<BankAccount> Accounts
        {
            get;
            set;
        }

        void Save(BankAccount account);

        BankAccount GetById(string id);

        void Delete(BankAccount account);
    }
}
