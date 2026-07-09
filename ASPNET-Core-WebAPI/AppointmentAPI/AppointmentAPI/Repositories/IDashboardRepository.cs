using AppointmentAPI.DTOs;

namespace AppointmentAPI.Repositories;

public interface IDashboardRepository
{
    Task<AdminDashboardDto> GetAdminDashboardAsync(int doctorCount, int patientCount);
    Task<DoctorDashboardDto> GetDoctorDashboardAsync(int doctorId);
    Task<PatientDashboardDto> GetPatientDashboardAsync(int userId);
}