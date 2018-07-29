namespace BankSystem
{
    /// <summary>
    /// Factory of gold accounts.
    /// </summary>
    public class GoldAccountFactory : BankAccountFactory
    {
        public override BankAccount CreateAccount(IAccountNumberGenerator generator, AccountHolder holder) =>
            new GoldAccount(generator, holder);
    }
}
