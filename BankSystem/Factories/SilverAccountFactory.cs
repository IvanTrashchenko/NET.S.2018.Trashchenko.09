namespace BankSystem
{
    /// <summary>
    /// Factory of silver accounts.
    /// </summary>
    public class SilverAccountFactory : BankAccountFactory
    {
        public override BankAccount CreateAccount(IAccountNumberGenerator generator, AccountHolder holder) =>
            new SilverAccount(generator, holder);
    }
}
