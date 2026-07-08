using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.DTOs;

public class CreateReviewDto
{
    [Range(1, 5)]
    public int Rating { get; set; }

    [MaxLength(500)]
    public string Comment { get; set; } = "";
}