using AppointmentAPI.DTOs;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

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
    [HttpGet]
    public async Task<IActionResult> GetAppointments()
    {
        var appointments = await _appointmentService.GetAllAppointments();

        return Ok(appointments);
    }

    // GET: api/appointments/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var appointment = await _appointmentService.GetAppointmentById(id);

        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        return Ok(appointment);
    }

    // POST: api/appointments
    [HttpPost]
    public async Task<IActionResult> CreateAppointment(CreateAppointmentDto appointmentDto)
    {
        var appointment = await _appointmentService.CreateAppointment(appointmentDto);

        return Ok(appointment);
    }

    // PUT: api/appointments/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(
        int id,
        UpdateAppointmentDto appointmentDto)
    {
        var appointment = await _appointmentService.UpdateAppointment(id, appointmentDto);

        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        return Ok(appointment);
    }

    // DELETE: api/appointments/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var result = await _appointmentService.DeleteAppointment(id);

        if (!result)
        {
            return NotFound("Appointment not found");
        }

        return Ok("Appointment Deleted Successfully");
    }
}