namespace AppointmentAPI.DTOs;

public class AdminDashboardDto
{
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int CancelledAppointments { get; set; }
    public int TotalDoctors { get; set; }
    public int TotalPatients { get; set; }
}