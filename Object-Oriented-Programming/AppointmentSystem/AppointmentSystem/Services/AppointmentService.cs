using AppointmentSystem.Interfaces;
using AppointmentSystem.Models;
using AppointmentSystem.Exceptions;

namespace AppointmentSystem.Services;

public class AppointmentService : IAppointmentService
{
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    public void CreateAppointment(Appointment appointment)
    {
        if (appointment.AppointmentDate < DateTime.Now)
        {
            throw new PastAppointmentException();
        }

        bool alreadyBooked = Appointments.Any( x => x.AppointmentDate.Date == appointment.AppointmentDate.Date && 
        x.AppointmentDate.Hour == appointment.AppointmentDate.Hour && 
        x.AppointmentDate.Minute == appointment.AppointmentDate.Minute);

        if (alreadyBooked)
        {
            throw new SlotAlreadyBookedException();
        }

        Appointments.Add(appointment);
        Console.WriteLine("Appointment Created Successfully");
    }

    public void CancelAppointment(int id)
    {
        Appointment? appointment = Appointments.FirstOrDefault(x => x.Id == id);
        if (appointment == null)
        {
            Console.WriteLine("Appointment not found");
            return;
        }
        appointment.Status = "Cancelled";
        Console.WriteLine("Appointment Cancelled");
    }

    public void ShowAppointments()
    {
        foreach (Appointment appointment in Appointments)
        {
            Console.WriteLine($"Customer: {appointment.Customer.Name}");
            Console.WriteLine($"Service: {appointment.Service.Name}");
            Console.WriteLine($"Date: {appointment.AppointmentDate}");
            Console.WriteLine($"Status: {appointment.Status}");
            Console.WriteLine("----------------");
        }
    }
}