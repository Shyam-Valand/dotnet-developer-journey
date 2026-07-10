using AppointmentAPI.Constants;
using AppointmentAPI.Data;
using AppointmentAPI.DTOs;
using AppointmentAPI.Exceptions;
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
            .Include(x => x.Doctor)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Appointment>> GetByDoctorIdAsync(int doctorId)
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .Include(x => x.Doctor)
            .Where(x => x.DoctorId == doctorId)
            .ToListAsync();
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
    }

    public void Delete(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
    }

    public async Task<bool> ExistsAsync(int serviceId, DateTime appointmentDate)
    {
        return await _context.Appointments.AnyAsync(x =>
                x.ServiceId == serviceId &&
                x.AppointmentDate == appointmentDate &&
                x.Status != AppointmentStatus.Cancelled
            );
    }

    public async Task<List<Appointment>> GetByUserIdAsync(int userId)
    {
        return await _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .Include(x => x.Doctor)
            .Where(x => x.UserId == userId)
            .ToListAsync();
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
                x.Status != AppointmentStatus.Cancelled &&
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

    public async Task<Appointment?> GetAppointmentWithDoctorAsync(int id)
    {
        return await _context.Appointments
            .Include(a => a.Customer)
            .Include(a => a.Service)
            .Include(a => a.Doctor)
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<PagedResultDto<Appointment>> SearchAppointmentsAsync(
    AppointmentSearchDto dto,
    string role,
    int userId)
    {
        var query = _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .Include(x => x.Doctor)
            .AsQueryable();

        // Role-based filtering
        if (role == "Patient")
        {
            query = query.Where(x => x.UserId == userId);
        }
        else if (role == "Doctor")
        {
            query = query.Where(x => x.DoctorId == userId);
        }

        // Optional filters
        if (!string.IsNullOrWhiteSpace(dto.Status))
        {
            query = query.Where(x => x.Status == dto.Status);
        }

        if (dto.AppointmentDate.HasValue)
        {
            query = query.Where(x =>
                x.AppointmentDate.Date == dto.AppointmentDate.Value.Date);
        }

        if (dto.DoctorId.HasValue)
        {
            query = query.Where(x => x.DoctorId == dto.DoctorId);
        }

        if (dto.ServiceId.HasValue)
        {
            query = query.Where(x => x.ServiceId == dto.ServiceId);
        }

        if (dto.PatientId.HasValue)
        {
            query = query.Where(x => x.CustomerId == dto.PatientId);
        }

        // Validate pagination values
        var pageNumber = dto.PageNumber <= 0 ? 1 : dto.PageNumber;
        var pageSize = dto.PageSize <= 0 ? 10 : dto.PageSize;

        // Sorting
        query = dto.SortBy?.ToLower() switch
        {
            "date" or "appointmentdate" => dto.Descending
                ? query.OrderByDescending(x => x.AppointmentDate)
                : query.OrderBy(x => x.AppointmentDate),

            "status" => dto.Descending
                ? query.OrderByDescending(x => x.Status)
                : query.OrderBy(x => x.Status),

            _ => query.OrderBy(x => x.Id)
        };

        // Total records
        var totalRecords = await query.CountAsync();

        // Pagination
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResultDto<Appointment>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
        };
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}