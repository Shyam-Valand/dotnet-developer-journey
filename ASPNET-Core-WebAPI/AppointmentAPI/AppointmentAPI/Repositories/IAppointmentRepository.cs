using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAll();
    Task<Appointment?> GetById(int id);
    Task Add(Appointment appointment);
    void Delete(Appointment appointment);

    Task<bool> Exists(int serviceId,DateTime appointmentDate);

    Task Save();
}