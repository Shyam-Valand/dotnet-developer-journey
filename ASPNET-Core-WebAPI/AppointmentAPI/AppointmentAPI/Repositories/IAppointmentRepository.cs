using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAllAsync();

    Task<Appointment?> GetByIdAsync(int id);

    Task AddAsync(Appointment appointment);

    void Delete(Appointment appointment);

    Task<bool> ExistsAsync(
        int serviceId,
        DateTime appointmentDate
    );

    Task SaveAsync();
}