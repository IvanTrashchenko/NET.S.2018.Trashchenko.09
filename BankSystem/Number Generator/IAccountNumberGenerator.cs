namespace BankSystem
{
    /// <summary>
    /// Interface for method of generating account's ID.
    /// </summary>
    public interface IAccountNumberGenerator
    {
        string GenerateAccountNumber(BankAccount account);
    }
}
