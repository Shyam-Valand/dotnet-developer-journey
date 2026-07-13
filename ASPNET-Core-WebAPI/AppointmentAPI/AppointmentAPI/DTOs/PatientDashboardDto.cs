namespace AppointmentAPI.DTOs;

public class PatientDashboardDto
{
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int UpcomingAppointments { get; set; }
    public int CancelledAppointments { get; set; }
}