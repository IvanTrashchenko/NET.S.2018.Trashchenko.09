namespace BankSystem
{
    /// <summary>
    /// Abstract factory class for creating new accounts.
    /// </summary>
    public abstract class BankAccountFactory
    {
        public abstract BankAccount CreateAccount(IAccountNumberGenerator generator, AccountHolder holder);
    }
}