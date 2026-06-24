using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;
using AppointmentAPI.Exceptions;

namespace AppointmentAPI.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
    }

    public void Delete(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
    }

    public async Task<bool> ExistsAsync(int serviceId,DateTime appointmentDate)
    {
        return await _context.Appointments.AnyAsync(x =>
                x.ServiceId == serviceId &&
                x.AppointmentDate == appointmentDate &&
                x.Status != "Cancelled"
            );
    }

    public async Task<bool> HasOverlappingAppointmentAsync(
    int serviceId,
    DateTime startTime,
    DateTime endTime,
    int? excludeAppointmentId = null)
    {
        return await _context.Appointments
            .Include(x => x.Service)
            .AnyAsync(x =>
                x.ServiceId == serviceId &&
                x.Id != excludeAppointmentId &&
                x.Status != "Cancelled" &&
                startTime < x.AppointmentDate.AddMinutes(
                    x.Service!.DurationMinutes
                ) &&
                endTime > x.AppointmentDate
            );
    }

    public async Task<int> GetServiceDurationAsync(int serviceId)
    {
        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceId);

        if (service == null)
        {
            throw new NotFoundException(
                "Service not found"
            );
        }

        return service.DurationMinutes;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}