using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface IDoctorAvailabilityRepository
{
    Task<List<DoctorAvailability>> GetByDoctorIdAsync(int doctorId);

    Task<DoctorAvailability?> GetByIdAsync(int id);

    Task AddAsync(DoctorAvailability availability);

    void Delete(DoctorAvailability availability);

    Task SaveAsync();
}