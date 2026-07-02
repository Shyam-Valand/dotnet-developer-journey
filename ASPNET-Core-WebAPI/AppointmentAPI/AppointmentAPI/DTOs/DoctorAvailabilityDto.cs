namespace AppointmentAPI.DTOs;

public class DoctorAvailabilityDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}