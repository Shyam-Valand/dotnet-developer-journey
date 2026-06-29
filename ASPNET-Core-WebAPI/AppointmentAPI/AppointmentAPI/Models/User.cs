namespace AppointmentAPI.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public required string Role { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
}