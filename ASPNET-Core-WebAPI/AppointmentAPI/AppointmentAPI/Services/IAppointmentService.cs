using AppointmentAPI.DTOs;
using AppointmentAPI.Models;

namespace AppointmentAPI.Services;

public interface IAppointmentService
{
    List<AppointmentDto> GetAllAppointments();
    AppointmentDto? GetAppointmentById(int id);
    Appointment CreateAppointment(
        CreateAppointmentDto appointmentDto
    );
    Appointment? UpdateAppointment(
        int id,
        UpdateAppointmentDto appointmentDto
    );
    bool DeleteAppointment(int id);
}