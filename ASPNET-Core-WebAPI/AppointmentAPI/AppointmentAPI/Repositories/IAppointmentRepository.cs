using AppointmentAPI.DTOs;
using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAllAsync();

    Task<Appointment?> GetByIdAsync(int id);

    Task AddAsync(Appointment appointment);

    void Delete(Appointment appointment);

    Task<bool> ExistsAsync(int serviceId, DateTime appointmentDate);

    Task<int> GetServiceDurationAsync(int serviceId);

    Task<List<Appointment>> GetByUserIdAsync(int userId);

    Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);

    Task<bool> HasOverlappingAppointmentAsync(
        int serviceId,
        DateTime startTime,
        DateTime endTime,
        int? excludeAppointmentId = null
    );

    Task<Appointment?> GetAppointmentWithDoctorAsync(int id);

    Task<List<Appointment>> SearchAppointmentsAsync(
        AppointmentSearchDto dto,
        string role,
        int userId
    );

    Task SaveAsync();
}