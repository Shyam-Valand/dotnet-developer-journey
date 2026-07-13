using AppointmentAPI.Data;
using AppointmentAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _context;

    public DashboardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AdminDashboardDto> GetAdminDashboardAsync(int doctorCount, int patientCount)
    {
        return new AdminDashboardDto
        {
            TotalAppointments = await _context.Appointments.CountAsync(),
            CompletedAppointments = await _context.Appointments.CountAsync(x => x.Status == "Completed"),
            CancelledAppointments = await _context.Appointments.CountAsync(x => x.Status == "Cancelled"),
            TotalDoctors = doctorCount,
            TotalPatients = patientCount
        };
    }

    public async Task<DoctorDashboardDto> GetDoctorDashboardAsync(int doctorId)
    {
        return new DoctorDashboardDto
        {
            TotalAppointments = await _context.Appointments.CountAsync(x => x.DoctorId == doctorId),
            CompletedAppointments = await _context.Appointments.CountAsync(x => x.DoctorId == doctorId && x.Status == "Completed"),
            PendingAppointments = await _context.Appointments.CountAsync(x => x.DoctorId == doctorId && x.Status == "Booked"),
            AverageRating = await _context.Reviews
                .Where(x => x.Appointment!.DoctorId == doctorId)
                .AverageAsync(x => (double?)x.Rating) ?? 0
        };
    }

    public async Task<PatientDashboardDto> GetPatientDashboardAsync(int userId)
    {
        return new PatientDashboardDto
        {
            TotalAppointments = await _context.Appointments.CountAsync(x => x.UserId == userId),
            CompletedAppointments = await _context.Appointments.CountAsync(x => x.UserId == userId && x.Status == "Completed"),
            UpcomingAppointments = await _context.Appointments.CountAsync(x => x.UserId == userId && x.Status == "Booked"),
            CancelledAppointments = await _context.Appointments.CountAsync(x => x.UserId == userId && x.Status == "Cancelled")
        };
    }
}