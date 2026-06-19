namespace AppointmentAPI.DTOs;

public class CreateAppointmentDto
{
    public int CustomerId { get; set; }
    public int ServiceId { get; set; }
    public DateTime AppointmentDate { get; set; }
}