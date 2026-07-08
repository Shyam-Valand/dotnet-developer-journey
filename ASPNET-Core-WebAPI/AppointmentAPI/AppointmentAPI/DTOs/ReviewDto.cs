namespace AppointmentAPI.DTOs;

public class ReviewDto
{
    public int Id { get; set; }

    public string PatientName { get; set; } = "";

    public string DoctorName { get; set; } = "";

    public int Rating { get; set; }

    public string Comment { get; set; } = "";

    public DateTime AppointmentDate { get; set; }
}