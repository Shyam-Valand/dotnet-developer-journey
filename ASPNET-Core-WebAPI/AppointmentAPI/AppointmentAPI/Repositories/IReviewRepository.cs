using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface IReviewRepository
{
    Task AddAsync(Review review);

    Task<Review?> GetByAppointmentIdAsync(int appointmentId);

    Task<List<Review>> GetDoctorReviewsAsync(int doctorId);

    Task<double> GetDoctorAverageRatingAsync(int doctorId);

    Task<Appointment?> GetCompletedAppointmentAsync(int appointmentId);

    Task SaveAsync();
}