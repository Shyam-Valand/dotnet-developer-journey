namespace OOPFundamentals.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public Customer(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public void DisplayCustomer()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Email: {Email}");
    }
}