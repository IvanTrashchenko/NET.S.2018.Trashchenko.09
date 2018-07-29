namespace BankSystem
{
    /// <summary>
    /// Bank account of base status.
    /// </summary>
    public class BaseAccount : BankAccount
    {
        public BaseAccount(
            IAccountNumberGenerator generator,
            AccountHolder holder,
            decimal balance = 0m,
            int bonusPoints = 0)
            : base(generator, holder, AccountStatus.Base, balance, bonusPoints)
        {
        }

        protected override int CalculateBonusPoints(decimal value) => (int)(value * 0.1m + this.Balance * 0.1m);
    }
}