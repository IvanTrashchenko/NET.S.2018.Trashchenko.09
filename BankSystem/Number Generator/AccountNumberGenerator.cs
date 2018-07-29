using System;

namespace BankSystem
{
    /// <summary>
    /// Class which implements GenerateAccountNumber method.
    /// </summary>
    public class AccountNumberGenerator : IAccountNumberGenerator
    {
        public string GenerateAccountNumber(BankAccount account)
        {
            return Math.Abs(account.GetHashCode()).ToString();
        }
    }
}
