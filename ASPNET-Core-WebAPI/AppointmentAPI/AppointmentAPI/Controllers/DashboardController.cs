using AppointmentAPI.DTOs;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    // GET: api/dashboard/admin
    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public async Task<IActionResult> GetAdminDashboard()
    {
        var dashboard = await _dashboardService.GetAdminDashboardAsync();

        return Ok(
            new ApiResponse<AdminDashboardDto>
            (
                true,
                "Admin dashboard fetched successfully.",
                dashboard
            )
        );
    }

    // GET: api/dashboard/doctor
    [Authorize(Roles = "Doctor")]
    [HttpGet("doctor")]
    public async Task<IActionResult> GetDoctorDashboard()
    {
        var dashboard = await _dashboardService.GetDoctorDashboardAsync();

        return Ok(
            new ApiResponse<DoctorDashboardDto>
            (
                true,
                "Doctor dashboard fetched successfully.",
                dashboard
            )
        );
    }

    // GET: api/dashboard/patient
    [Authorize(Roles = "Patient")]
    [HttpGet("patient")]
    public async Task<IActionResult> GetPatientDashboard()
    {
        var dashboard = await _dashboardService.GetPatientDashboardAsync();

        return Ok(
            new ApiResponse<PatientDashboardDto>
            (
                true,
                "Patient dashboard fetched successfully.",
                dashboard
            )
        );
    }
}