namespace BankSystem
{
    /// <summary>
    /// Factory of platinum accounts.
    /// </summary>
    public class PlatinumAccountFactory : BankAccountFactory
    {
        public override BankAccount CreateAccount(IAccountNumberGenerator generator, AccountHolder holder) =>
            new PlatinumAccount(generator, holder);
    }
}
