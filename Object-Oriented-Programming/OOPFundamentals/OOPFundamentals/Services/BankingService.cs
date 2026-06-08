using OOPFundamentals.Interfaces;
using OOPFundamentals.Models;

namespace OOPFundamentals.Services;

public class BankingService : IBankingService
{
    private readonly BankAccount account;

    public BankingService(BankAccount bankAccount)
    {
        account = bankAccount;
    }

    public void Deposit(decimal amount)
    {
        account.Deposit(amount);
    }

    public void Withdraw(decimal amount)
    {
        account.Withdraw(amount);
    }

    public void ShowBalance()
    {
        account.ShowBalance();
    }
}