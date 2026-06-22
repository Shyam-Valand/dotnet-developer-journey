using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Appointments
            .AnyAsync(x =>
                x.ServiceId == serviceId &&
                x.AppointmentDate == appointmentDate &&
                x.Status != "Cancelled"
            );
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}