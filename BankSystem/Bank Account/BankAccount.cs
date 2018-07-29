using System;

namespace BankSystem
{
    /// <summary>
    /// Abstract class of bank account.
    /// </summary>
    public abstract class BankAccount : IEquatable<BankAccount>
    {
        #region Fields

        /// <summary>
        /// ID of account.
        /// </summary>
        private string id;

        /// <summary>
        /// Account holder's information.
        /// </summary>
        private AccountHolder holder;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="generator">Generator of ID.</param>
        /// <param name="holder">Account holder.</param>
        /// <param name="balance">Account's balance.</param>
        /// <param name="bonusPoints">Account's bonus points.</param>
        /// <param name="status">Status of account.</param>
        protected BankAccount(
            IAccountNumberGenerator generator,
            AccountHolder holder,
            AccountStatus status = AccountStatus.Base,
            decimal balance = 0m,
            int bonusPoints = 0)
        {
            this.Holder = holder;
            this.Balance = balance;
            this.BonusPoints = bonusPoints;
            this.Status = status;
            this.Id = generator.GenerateAccountNumber(this); // ?? throw new ArgumentNullException(nameof(generator));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets account holder's info.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when AccountHolder value is null.</exception>
        public AccountHolder Holder
        {
            get => this.holder;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                this.holder = value;
            }
        }

        /// <summary>
        /// Gets status of account.
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// Gets current balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets current amount of bonus points.
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Gets ID of account.
        /// </summary>
        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }

        #endregion

        #region Service methods

        /// <summary>
        /// Deposite operation.
        /// </summary>
        /// <param name="value">Money to deposite.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is out of range.</exception>
        public void Deposite(decimal value)
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} is out of range.");
            }

            this.Balance += value;
            this.BonusPoints += this.CalculateBonusPoints(value);
        }

        /// <summary>
        /// Withdraw operation.
        /// </summary>
        /// <param name="value">Money to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when money value is out of range.</exception>
        /// <exception cref="InvalidBalanceException">Thrown when balance is insufficient.</exception>
        public void Withdraw(decimal value)
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} is out of range.");
            }

            if (value > this.Balance)
            {
                throw new InvalidBalanceException("Insufficient funds.");
            }

            this.Balance -= value;

            int calculated = this.CalculateBonusPoints(value);

            this.BonusPoints = this.BonusPoints > calculated ? this.BonusPoints - calculated : 0;
        }

        /// <summary>
        /// Transfer operation.
        /// </summary>
        /// <param name="value">Money to transfer.</param>
        /// <param name="recipient">Recipient.</param>
        /// <exception cref="ArgumentNullException">Thrown when recipient is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when money value is out of range.</exception>
        public void Transfer(decimal value, BankAccount recipient)
        {
            if (recipient == null)
            {
                throw new ArgumentNullException($"{nameof(recipient)} can not be null.");
            }

            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} is out of range.");
            }

            this.Withdraw(value);
            recipient.Deposite(value);
        }

        /// <summary>
        /// Method for calculating bonus points depending on the specified amount of money.
        /// </summary>
        /// <param name="value">Money amount.</param>
        /// <returns><see cref="int"/> of bonus points.</returns>
        protected abstract int CalculateBonusPoints(decimal value);

        #endregion

        #region Equality and formatting members

        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.id, other.id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((BankAccount)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashResult = this.Holder.FirstName.GetHashCode() * 397;
                hashResult *= this.Holder.LastName.GetHashCode() * 397;
                return hashResult ^ (int)this.Status;
            }
        }

        public override string ToString()
        {
            return $"{nameof(this.Holder)}: {this.Holder}, {nameof(this.Status)}: {this.Status}, {nameof(this.Balance)}: {this.Balance}, {nameof(this.BonusPoints)}: {this.BonusPoints}, {nameof(this.Id)}: {this.Id}";
        }

        #endregion
    }
}