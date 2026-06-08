using OOPFundamentals.Models;
using OOPFundamentals.Services;


Console.WriteLine("Day 3 & 4 - Object Oriented Programming");
Console.WriteLine("-----------------------------------");


// Classes, Objects, Properties and Constructor Practice with Customer class

Customer customer = new Customer(1, "Shyam", "test@gmail.com");
customer.DisplayCustomer();

Console.WriteLine("-----------------------------------");


// Encapsulation Practice with BankAccount class

BankAccount account = new BankAccount("ACC001", 10000);

account.ShowBalance();
account.Deposit(5000);
account.Withdraw(3000);
account.Withdraw(20000);
account.ShowBalance();

Console.WriteLine("-----------------------------------");


// Inheritance Practice with User and Admin classes

Admin admin = new Admin(1,"Shyam","admin@test.com","System Admin");

admin.DisplayInfo();

Console.WriteLine("-----------------------------------");


// Interface and Service Layer Practice

BankAccount bankAccount = new BankAccount("ACC002", 20000);


BankingService bankingService = new BankingService(bankAccount);


bankingService.ShowBalance();
bankingService.Deposit(10000);
bankingService.Withdraw(5000);
bankingService.ShowBalance();