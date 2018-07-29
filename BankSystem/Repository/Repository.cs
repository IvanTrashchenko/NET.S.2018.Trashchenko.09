using System;
using System.Collections.Generic;

namespace BankSystem
{
    /// <summary>
    /// Repository class for working with bank accounts.
    /// </summary>
    public class Repository : IRepository
    {
        private List<BankAccount> accounts;

        public Repository()
        {
            this.Accounts = new List<BankAccount>();
        }

        public Repository(params BankAccount[] accounts)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException($"{nameof(accounts)} can not be null.");
            }

            if (accounts.Length == 0)
            {
                throw new ArgumentException($"{nameof(accounts)} can not be empty.");
            }

            this.Accounts = new List<BankAccount>(accounts);
        }

        public List<BankAccount> Accounts
        {
            get => this.accounts;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException($"{nameof(value)} can not be null.");
                }

                this.accounts = value;
            }
        }

        public int Count
        {
            get => this.Accounts.Count;
        }

        public void Delete(BankAccount account)
        {
            this.Accounts.Remove(account);
        }

        public BankAccount GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"{nameof(id)} can not be null or empty.");
            }

            return this.Accounts.Find(x => x.Id == id);
        }

        public void Save(BankAccount account)
        {
            this.Accounts.Add(account);
        }
    }
}