using AppointmentAPI.DTOs;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    // GET: api/appointments
    [Authorize(Roles = "Patient")]
    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();

        return Ok(
            new ApiResponse<List<AppointmentDto>>
            (
                true,
                "Appointments fetched successfully",
                appointments
            )
        );
    }

    // GET: api/appointments/doctor
    [Authorize(Roles = "Doctor")]
    [HttpGet("doctor")]
    public async Task<IActionResult> GetDoctorAppointments()
    {
        var appointments = await _appointmentService.GetDoctorAppointmentsAsync();

        return Ok(
            new ApiResponse<List<AppointmentDto>>
            (
                true,
                "Doctor appointments fetched successfully",
                appointments
            )
        );
    }

    // GET: api/appointments/1
    [Authorize(Roles = "Patient")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

        if (appointment == null)
        {
            return NotFound(
                new ApiResponse<string>
                (
                    false,
                    "Appointment not found",
                    null
                )
            );
        }

        return Ok(
            new ApiResponse<AppointmentDto>
            (
                true,
                "Appointment fetched successfully",
                appointment
            )
        );
    }

    // POST: api/appointments
    [Authorize(Roles = "Patient")]
    [HttpPost]
    public async Task<IActionResult> CreateAppointment(CreateAppointmentDto appointmentDto)
    {
        var appointment = await _appointmentService.CreateAppointmentAsync(appointmentDto);

        return Ok(
            new ApiResponse<AppointmentDto>
            (
                true,
                "Appointment created successfully",
                appointment
            )
        );
    }

    // PUT: api/appointments/1
    [Authorize(Roles = "Patient")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto appointmentDto)
    {
        var appointment = await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);

        if (appointment == null)
        {
            return NotFound(
                new ApiResponse<string>
                (
                    false,
                    "Appointment not found",
                    null
                )
            );
        }

        return Ok(
            new ApiResponse<object>
            (
                true,
                "Appointment updated successfully",
                appointment
            )
        );
    }

    // PUT: api/appointments/1/assign-doctor
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/assign-doctor")]
    public async Task<IActionResult> AssignDoctor(int id, AssignDoctorDto dto)
    {
        await _appointmentService.AssignDoctorAsync(id, dto);

        return Ok(
            new ApiResponse<string>
            (
                true,
                "Doctor assigned successfully",
                null
            )
        );
    }

    // DELETE: api/appointments/1
    [Authorize(Roles = "Patient")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var result = await _appointmentService.DeleteAppointmentAsync(id);

        if (!result)
        {
            return NotFound(
                new ApiResponse<string>
                (
                    false,
                    "Appointment not found",
                    null
                )
            );
        }

        return Ok(
            new ApiResponse<string>
            (
                true,
                "Appointment deleted successfully",
                null
            )
        );
    }
}