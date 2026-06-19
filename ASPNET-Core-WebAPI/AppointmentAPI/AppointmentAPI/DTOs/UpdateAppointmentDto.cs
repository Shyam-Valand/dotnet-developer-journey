namespace AppointmentAPI.DTOs;

public class UpdateAppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "";
}