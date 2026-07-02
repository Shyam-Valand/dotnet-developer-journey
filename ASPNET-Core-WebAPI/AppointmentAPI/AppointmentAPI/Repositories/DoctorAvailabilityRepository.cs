using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Repositories;

public class DoctorAvailabilityRepository : IDoctorAvailabilityRepository
{
    private readonly AppDbContext _context;

    public DoctorAvailabilityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DoctorAvailability>> GetByDoctorIdAsync(int doctorId)
    {
        return await _context.DoctorAvailabilities.Where(x => x.DoctorId == doctorId).ToListAsync();
    }

    public async Task<DoctorAvailability?> GetByIdAsync(int id)
    {
        return await _context.DoctorAvailabilities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(DoctorAvailability availability)
    {
        await _context.DoctorAvailabilities.AddAsync(availability);
    }

    public void Delete(DoctorAvailability availability)
    {
        _context.DoctorAvailabilities.Remove(availability);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}