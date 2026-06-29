namespace AppointmentAPI.DTOs;

public class CreateAppointmentDto
{
    public int ServiceId { get; set; }
    public DateTime AppointmentDate { get; set; }
}