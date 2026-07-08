using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;

    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public async Task<Review?> GetByAppointmentIdAsync(int appointmentId)
    {
        return await _context.Reviews
            .FirstOrDefaultAsync(r => r.AppointmentId == appointmentId);
    }

    public async Task<List<Review>> GetDoctorReviewsAsync(int doctorId)
    {
        return await _context.Reviews
            .Include(r => r.Appointment!)
                .ThenInclude(a => a.Customer)
            .Include(r => r.Appointment!)
                .ThenInclude(a => a.Doctor)
            .Where(r => r.Appointment!.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task<double> GetDoctorAverageRatingAsync(int doctorId)
    {
        var ratings = await _context.Reviews
            .Where(r => r.Appointment!.DoctorId == doctorId)
            .Select(r => r.Rating)
            .ToListAsync();

        if (!ratings.Any())
            return 0;

        return ratings.Average();
    }

    public async Task<Appointment?> GetCompletedAppointmentAsync(int appointmentId)
    {
        return await _context.Appointments
            .Include(a => a.Customer)
            .Include(a => a.Doctor)
            .FirstOrDefaultAsync(a =>
                a.Id == appointmentId &&
                a.Status == "Completed");
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}