using AppointmentAPI.Data;
using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Services;

public class AppointmentService : IAppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public List<AppointmentDto> GetAllAppointments()
    {
        return _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .Select(x => new AppointmentDto
            {
                Id = x.Id,
                CustomerName = x.Customer!.Name,
                ServiceName = x.Service!.Name,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            })
            .ToList();
    }

    public AppointmentDto? GetAppointmentById(int id)
    {
        return _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .Where(x => x.Id == id)
            .Select(x => new AppointmentDto
            {
                Id = x.Id,
                CustomerName = x.Customer!.Name,
                ServiceName = x.Service!.Name,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            })
            .FirstOrDefault();
    }

    public Appointment CreateAppointment(CreateAppointmentDto dto)
    {
        // Rule 1: Prevent past appointments
        if (dto.AppointmentDate < DateTime.Now)
        {
            throw new Exception(
                "Appointment date cannot be in the past"
            );
        }

        // Rule 2: Prevent duplicate booking
        bool alreadyBooked = _context.Appointments.Any(x =>
                x.ServiceId == dto.ServiceId &&
                x.AppointmentDate == dto.AppointmentDate &&
                x.Status != "Cancelled"
                );

        if (alreadyBooked)
        {
            throw new Exception(
                "This appointment slot is already booked"
            );
        }

        var appointment = new Appointment
        {
            CustomerId = dto.CustomerId,
            ServiceId = dto.ServiceId,
            AppointmentDate = dto.AppointmentDate,
            Status = "Booked"
        };

        _context.Appointments.Add(appointment);
        _context.SaveChanges();


        return appointment;
    }

    public Appointment? UpdateAppointment(int id,UpdateAppointmentDto dto)
    {
        var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);

        if (appointment == null)
            return null;

        appointment.AppointmentDate = dto.AppointmentDate;
        appointment.Status = dto.Status;
        _context.SaveChanges();

        return appointment;
    }

    public bool DeleteAppointment(int id)
    {
        var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);

        if (appointment == null)
            return false;

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();

        return true;
    }
}