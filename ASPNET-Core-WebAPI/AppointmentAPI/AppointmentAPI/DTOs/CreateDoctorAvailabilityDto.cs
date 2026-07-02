namespace AppointmentAPI.DTOs;

public class CreateDoctorAvailabilityDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}