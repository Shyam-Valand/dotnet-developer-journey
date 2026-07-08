using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.Models;

public class Review
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public Appointment? Appointment { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(500)]
    public string Comment { get; set; } = "";
}