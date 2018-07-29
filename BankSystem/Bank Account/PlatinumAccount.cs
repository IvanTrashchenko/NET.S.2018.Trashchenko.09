namespace BankSystem
{
    /// <summary>
    /// Bank account of platinum status.
    /// </summary>
    public class PlatinumAccount : BankAccount
    {
        public PlatinumAccount(
            IAccountNumberGenerator generator,
            AccountHolder holder,
            decimal balance = 0m,
            int bonusPoints = 0)
            : base(generator, holder, AccountStatus.Platinum, balance, bonusPoints)
        {
        }

        protected override int CalculateBonusPoints(decimal value) => (int)(value * 0.25m + this.Balance * 0.25m);
    }
}