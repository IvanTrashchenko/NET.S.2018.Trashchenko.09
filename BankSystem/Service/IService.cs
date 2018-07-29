namespace BankSystem
{
    /// <summary>
    /// Interface for bank service realisation.
    /// </summary>
    public interface IService
    {
        IRepository Repository
        {
            get;
            set;
        }

        void CloseAccount(string id);

        void Deposite(string id, decimal value);

        void OpenAccount(IAccountNumberGenerator generator, AccountHolder holder, BankAccountFactory accountFactory = null);

        void Withdraw(string id, decimal value);

        void Transfer(string senderId, string recipientId, decimal value);

    }
}