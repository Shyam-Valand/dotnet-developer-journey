namespace AppointmentAPI.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string ServiceName { get; set; } = "";
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "";
}