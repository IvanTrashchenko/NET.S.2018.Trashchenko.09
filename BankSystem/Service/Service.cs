using System;

namespace BankSystem
{
    /// <summary>
    /// Service for working with bank accounts repository.
    /// </summary>
    public class Service : IService
    {
        private IRepository repository;

        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public IRepository Repository
        {
            get => this.repository;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException($"{nameof(value)} can not be null.");
                }

                this.repository = value;
            }
        }

        public void CloseAccount(string id)
        {
            BankAccount account = this.Repository.GetById(id);

            this.Repository.Delete(account);
        }

        public void Deposite(string id, decimal value)
        {
            BankAccount account = this.Repository.GetById(id);
            account.Deposite(value);
        }

        public void OpenAccount(
            IAccountNumberGenerator generator,
            AccountHolder holder,
            BankAccountFactory factory = null)
        {
            if (factory == null)
            {
                factory = new BaseAccountFactory();
            }

            BankAccount account = factory.CreateAccount(generator, holder);

            this.Repository.Save(account);
        }

        public void Withdraw(string id, decimal value)
        {
            BankAccount account = this.Repository.GetById(id);
            account.Withdraw(value);
        }

        public void Transfer(string senderId, string recipientId, decimal value)
        {
            BankAccount sender = this.Repository.GetById(senderId);
            BankAccount recipient = this.Repository.GetById(recipientId);
            sender.Transfer(value, recipient);
        }
    }
}