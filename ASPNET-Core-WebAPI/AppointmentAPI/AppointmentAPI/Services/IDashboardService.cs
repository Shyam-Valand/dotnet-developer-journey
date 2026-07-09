using AppointmentAPI.DTOs;

namespace AppointmentAPI.Services;

public interface IDashboardService
{
    Task<AdminDashboardDto> GetAdminDashboardAsync();
    Task<DoctorDashboardDto> GetDoctorDashboardAsync();
    Task<PatientDashboardDto> GetPatientDashboardAsync();
}