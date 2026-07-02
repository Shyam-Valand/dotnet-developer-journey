using AppointmentAPI.DTOs;

namespace AppointmentAPI.Services;

public interface IDoctorAvailabilityService
{
    Task<List<DoctorAvailabilityDto>> GetMyAvailabilityAsync();

    Task<DoctorAvailabilityDto> CreateAvailabilityAsync(CreateDoctorAvailabilityDto dto);

    Task<bool> DeleteAvailabilityAsync(int id);
}