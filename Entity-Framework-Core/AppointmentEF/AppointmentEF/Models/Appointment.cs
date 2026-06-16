namespace AppointmentEF.Models;

public class Appointment
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = "Booked";
}