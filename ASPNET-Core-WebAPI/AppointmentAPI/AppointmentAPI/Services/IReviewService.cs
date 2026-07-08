using AppointmentAPI.DTOs;

namespace AppointmentAPI.Services;

public interface IReviewService
{
    Task<ReviewDto> CreateReviewAsync(int appointmentId, CreateReviewDto dto);

    Task<List<ReviewDto>> GetDoctorReviewsAsync(int doctorId);

    Task<double> GetDoctorAverageRatingAsync(int doctorId);
}