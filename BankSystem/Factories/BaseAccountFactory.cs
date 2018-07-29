namespace BankSystem
{
    /// <summary>
    /// Factory of base accounts.
    /// </summary>
    public class BaseAccountFactory : BankAccountFactory
    {
        public override BankAccount CreateAccount(IAccountNumberGenerator generator, AccountHolder holder) =>
            new BaseAccount(generator, holder);
    }
}
