namespace BankSystem
{
    /// <summary>
    /// Bank account of silver status.
    /// </summary>
    public class SilverAccount : BankAccount
    {
        public SilverAccount(
            IAccountNumberGenerator generator,
            AccountHolder holder,
            decimal balance = 0m,
            int bonusPoints = 0)
            : base(generator, holder, AccountStatus.Silver, balance, bonusPoints)
        {
        }

        protected override int CalculateBonusPoints(decimal value) => (int)(value * 0.15m + this.Balance * 0.15m);
    }
}