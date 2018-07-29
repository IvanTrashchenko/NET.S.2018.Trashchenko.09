using System;

namespace BankSystem
{
    /// <summary>
    /// Exception of incorrect "withdraw" operation in <see cref="BankAccount"/> class when working with balance.
    /// </summary>
    public class InvalidBalanceException : Exception
    {
        public InvalidBalanceException()
        {
        }

        public InvalidBalanceException(string message) : base(message)
        {
        }

        public InvalidBalanceException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
