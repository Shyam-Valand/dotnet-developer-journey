using AppointmentAPI.DTOs;
using AppointmentAPI.Models;

namespace AppointmentAPI.Services;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAllAppointments();
    Task<AppointmentDto?> GetAppointmentById(int id);
    Task<Appointment> CreateAppointment(CreateAppointmentDto dto);
    Task<Appointment?> UpdateAppointment(int id,UpdateAppointmentDto dto);
    Task<bool> DeleteAppointment(int id);
}