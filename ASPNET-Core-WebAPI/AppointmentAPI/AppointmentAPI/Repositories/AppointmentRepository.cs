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

    public async Task<List<Appointment>> GetAll()
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .ToListAsync();
    }

    public async Task<Appointment?> GetById(int id)
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Add(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
    }

    public void Delete(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
    }

    public async Task<bool> Exists(int serviceId,DateTime appointmentDate)
    {
        return await _context.Appointments
            .AnyAsync(x =>
                x.ServiceId == serviceId &&
                x.AppointmentDate == appointmentDate &&
                x.Status != "Cancelled"
            );
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}