using AppointmentSystem.Models;

namespace AppointmentSystem.Interfaces;

public interface IAppointmentService
{
    void CreateAppointment(Appointment appointment);

    void CancelAppointment(int id);

    void ShowAppointments();

    Appointment? SearchAppointment(int id);
}