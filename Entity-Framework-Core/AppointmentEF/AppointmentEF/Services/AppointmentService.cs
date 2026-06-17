using AppointmentEF.Data;
using AppointmentEF.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentEF.Services;

public class AppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService()
    {
        _context = new AppDbContext();
    }

    public void CreateAppointment(Appointment appointment)
    {
        if (appointment.AppointmentDate < DateTime.Now)
        {
            Console.WriteLine("Cannot create appointment in the past");
            return;
        }

        bool alreadyBooked = _context.Appointments
            .Any(x =>
                x.AppointmentDate == appointment.AppointmentDate &&
                x.Status == "Booked"
            );

        if (alreadyBooked)
        {
            Console.WriteLine("This appointment slot is already booked");
            return;
        }

        _context.Appointments.Add(appointment);
        _context.SaveChanges();

        Console.WriteLine("Appointment Created Successfully");
    }

    public void ShowAppointments()
    {
        var appointments = _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .ToList();

        foreach(var appointment in appointments)
        {
            Console.WriteLine(
                $"{appointment.Id} - {appointment.Customer.Name} - {appointment.Service.Name} - {appointment.AppointmentDate.ToString("dd-MM-yyyy hh:mm tt")} - {appointment.Status}"
            );
        }
    }

    public Appointment? GetAppointmentById(int id)
    {
        return _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefault(x => x.Id == id);
    }

    public void CancelAppointment(int id)
    {
        var appointment = _context.Appointments
            .FirstOrDefault(x => x.Id == id);

        if(appointment == null)
        {
            Console.WriteLine("Appointment Not Found");
            return;
        }

        appointment.Status = "Cancelled";
        _context.SaveChanges();
        Console.WriteLine("Appointment Cancelled");
    }

    public void DeleteAppointment(int id)
    {
        var appointment = _context.Appointments
            .FirstOrDefault(x => x.Id == id);

        if(appointment == null)
        {
            Console.WriteLine("Appointment Not Found");
            return;
        }

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();

        Console.WriteLine("Appointment Deleted");
    }
}