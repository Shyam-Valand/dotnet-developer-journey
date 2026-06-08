namespace OOPFundamentals.Models;

public class BankAccount
{
    public string AccountNumber { get; set; }
    private decimal balance;

    public BankAccount(string accountNumber, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        if (openingBalance > 0)
        {
            balance = openingBalance;
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive");
            return;
        }
        
        balance += amount;

        Console.WriteLine($"Deposited: {amount}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }

        balance -= amount;

        Console.WriteLine($"Withdrawn: {amount}");
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Balance: {balance}");
    }
}