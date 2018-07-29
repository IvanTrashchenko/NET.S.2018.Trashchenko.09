using System;
using System.Text.RegularExpressions;

namespace BankSystem
{
    /// <summary>
    /// AccountHolder class.
    /// </summary>
    public class AccountHolder
    {
        #region Fields

        /// <summary>
        /// First name of account holder.
        /// </summary>
        private string firstName;

        /// <summary>
        /// Last name of account holder.
        /// </summary>
        private string lastName;

        /// <summary>
        /// Email of account holder.
        /// </summary>
        private string email;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHolder"/> class with default values.
        /// </summary>
        public AccountHolder()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountHolder"/> class.
        /// </summary>
        /// <param name="firstName">First name of account holder.</param>
        /// <param name="lastName">Last name of account holder.</param>
        /// <param name="email">Email of account holder.</param>
        public AccountHolder(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the first name is incorrect.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the first name value is null.</exception>
        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                Regex regex = new Regex(@"[A-Z]+[a-zA-Z]*");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                this.firstName = value;
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the last name is incorrect.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the last name value is null.</exception>
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                Regex regex = new Regex(@"[A-Z]+[a-zA-Z]*");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                this.lastName = value;
            }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the email is incorrect.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the email value is null.</exception>
        public string Email
        {
            get => this.email;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                Regex regex = new Regex(
                    @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                this.email = value;
            }
        }

        #endregion

        #region Formatting member

        public override string ToString()
        {
            return $"{nameof(this.FirstName)}: {this.FirstName}, {nameof(this.LastName)}: {this.LastName}, {nameof(this.Email)}: {this.Email}";
        }

        #endregion
    }
}