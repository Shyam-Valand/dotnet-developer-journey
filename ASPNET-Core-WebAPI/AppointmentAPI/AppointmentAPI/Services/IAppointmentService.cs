using AppointmentAPI.DTOs;
using AppointmentAPI.Models;

namespace AppointmentAPI.Services;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAllAppointmentsAsync();

    Task<AppointmentDto?> GetAppointmentByIdAsync(int id);

    Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto);

    Task<AppointmentDto?> UpdateAppointmentAsync(int id,UpdateAppointmentDto dto);

    Task<bool> DeleteAppointmentAsync(int id);

    Task AssignDoctorAsync(int appointmentId, AssignDoctorDto dto);

    Task<List<AppointmentDto>> GetDoctorAppointmentsAsync();

    Task<AppointmentDto> ConfirmAppointmentAsync(int id);

    Task<AppointmentDto> CompleteAppointmentAsync(int id);

    Task<AppointmentDto> CancelAppointmentAsync(int id);
}