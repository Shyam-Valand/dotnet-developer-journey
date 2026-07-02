using AppointmentAPI.DTOs;
using AppointmentAPI.Exceptions;
using AppointmentAPI.Models;
using AppointmentAPI.Repositories;

namespace AppointmentAPI.Services;

public class DoctorAvailabilityService : IDoctorAvailabilityService
{
    private readonly IDoctorAvailabilityRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public DoctorAvailabilityService(
        IDoctorAvailabilityRepository repository,
        ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<DoctorAvailabilityDto> CreateAvailabilityAsync(CreateDoctorAvailabilityDto dto)
    {
        var doctorId = _currentUserService.UserId;

        if (dto.StartTime >= dto.EndTime)
        {
            throw new BadRequestException("Start time must be earlier than end time.");
        }

        if (dto.StartTime < DateTime.Now)
        {
            throw new BadRequestException("Cannot create availability in the past.");
        }        

        var existingAvailability = await _repository.GetByDoctorIdAsync(doctorId);
        var hasOverlap = existingAvailability.Any(a => dto.StartTime < a.EndTime && dto.EndTime > a.StartTime);

        if (hasOverlap)
        {
            throw new BadRequestException("Doctor already has availability during this time.");
        }

        var availability = new DoctorAvailability
        {
            DoctorId = doctorId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime
        };

        await _repository.AddAsync(availability);
        await _repository.SaveAsync();

        return new DoctorAvailabilityDto
        {
            Id = availability.Id,
            StartTime = availability.StartTime,
            EndTime = availability.EndTime
        };
    }

    public async Task<List<DoctorAvailabilityDto>> GetMyAvailabilityAsync()
    {
        var doctorId = _currentUserService.UserId;

        var availability = await _repository.GetByDoctorIdAsync(doctorId);

        return availability.Select(a => new DoctorAvailabilityDto
        {
            Id = a.Id,
            StartTime = a.StartTime,
            EndTime = a.EndTime
        }).ToList();
    }

    public async Task<bool> DeleteAvailabilityAsync(int id)
    {
        var doctorId = _currentUserService.UserId;

        var availability = await _repository.GetByIdAsync(id);

        if (availability == null || availability.DoctorId != doctorId)
            return false;

        _repository.Delete(availability);
        await _repository.SaveAsync();

        return true;
    }
}