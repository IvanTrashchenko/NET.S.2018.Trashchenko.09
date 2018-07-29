namespace BankSystem
{
    /// <summary>
    /// Bank account of gold status.
    /// </summary>
    public class GoldAccount : BankAccount
    {
        public GoldAccount(
            IAccountNumberGenerator generator,
            AccountHolder holder,
            decimal balance = 0m,
            int bonusPoints = 0)
            : base(generator, holder, AccountStatus.Gold, balance, bonusPoints)
        {
        }

        protected override int CalculateBonusPoints(decimal value) => (int)(value * 0.2m + this.Balance * 0.2m);
    }
}