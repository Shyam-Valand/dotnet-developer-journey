using AppointmentSystem.Interfaces;
using AppointmentSystem.Models;

namespace AppointmentSystem.Services;

public class AppointmentService : IAppointmentService
{
    private List<Appointment> appointments = new List<Appointment>();

    public void CreateAppointment(Appointment appointment)
    {
        if (appointment.AppointmentDate < DateTime.Now)
        {
            Console.WriteLine("Cannot book past appointments");

            return;
        }

        bool alreadyBooked = appointments.Any( x => x.AppointmentDate.Date == appointment.AppointmentDate.Date && 
        x.AppointmentDate.Hour == appointment.AppointmentDate.Hour && 
        x.AppointmentDate.Minute == appointment.AppointmentDate.Minute);

        if (alreadyBooked)
        {
            Console.WriteLine("Time slot already booked");

            return;
        }
        appointments.Add(appointment);
        Console.WriteLine("Appointment Created Successfully");
    }

    public void CancelAppointment(int id)
    {
        Appointment? appointment = appointments.FirstOrDefault(x => x.Id == id);
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
        foreach (Appointment appointment in appointments)
        {
            Console.WriteLine($"Customer: {appointment.Customer.Name}");
            Console.WriteLine($"Service: {appointment.Service.Name}");
            Console.WriteLine($"Date: {appointment.AppointmentDate}");
            Console.WriteLine($"Status: {appointment.Status}");
            Console.WriteLine("----------------");
        }
    }
}