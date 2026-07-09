namespace AppointmentAPI.DTOs;

public class DoctorDashboardDto
{
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int PendingAppointments { get; set; }
    public double AverageRating { get; set; }
}