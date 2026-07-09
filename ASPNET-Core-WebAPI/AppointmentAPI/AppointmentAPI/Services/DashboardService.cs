using AppointmentAPI.DTOs;
using AppointmentAPI.Repositories;

namespace AppointmentAPI.Services;

public class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _dashboardRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;

    public DashboardService(
        IDashboardRepository dashboardRepository,
        ICurrentUserService currentUserService,
        IUserRepository userRepository)
    {
        _dashboardRepository = dashboardRepository;
        _currentUserService = currentUserService;
        _userRepository = userRepository;
    }

    public async Task<AdminDashboardDto> GetAdminDashboardAsync()
    {
        var doctorCount = await _userRepository.CountByRoleAsync("Doctor");
        var patientCount = await _userRepository.CountByRoleAsync("Patient");

        return await _dashboardRepository.GetAdminDashboardAsync(
            doctorCount,
            patientCount
        );
    }

    public async Task<DoctorDashboardDto> GetDoctorDashboardAsync()
    {
        return await _dashboardRepository.GetDoctorDashboardAsync(
            _currentUserService.UserId
        );
    }

    public async Task<PatientDashboardDto> GetPatientDashboardAsync()
    {
        return await _dashboardRepository.GetPatientDashboardAsync(
            _currentUserService.UserId
        );
    }
}