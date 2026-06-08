namespace OOPFundamentals.Models;

public class Admin : User
{
    public string Role { get; set; }

    public Admin(int id,string name,string email,string role ): base(id, name, email)
    {
        Role = role;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Role: {Role}");
    }
}