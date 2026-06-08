namespace OOPFundamentals.Interfaces;

public interface IBankingService
{
    void Deposit(decimal amount);

    void Withdraw(decimal amount);

    void ShowBalance();
}