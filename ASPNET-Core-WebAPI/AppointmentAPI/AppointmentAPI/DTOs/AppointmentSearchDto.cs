namespace AppointmentAPI.DTOs;

public class AppointmentSearchDto : PaginationDto
{
    public string? Status { get; set; }
    public DateTime? AppointmentDate { get; set; }
    public int? DoctorId { get; set; }
    public int? ServiceId { get; set; }
    public int? PatientId { get; set; }
}