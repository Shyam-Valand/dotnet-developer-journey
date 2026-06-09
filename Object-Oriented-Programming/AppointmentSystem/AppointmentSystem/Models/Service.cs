namespace AppointmentSystem.Models;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int DurationMinutes { get; set; }

    public decimal Price { get; set; }

    public Service(int id,string name,int durationMinutes,decimal price)
    {
        Id = id;
        Name = name;
        DurationMinutes = durationMinutes;
        Price = price;
    }
}