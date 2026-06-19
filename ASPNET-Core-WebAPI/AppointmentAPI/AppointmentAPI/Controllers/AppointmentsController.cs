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
    public IActionResult GetAppointments()
    {
        var appointments = _appointmentService.GetAllAppointments();

        return Ok(appointments);
    }


    // GET: api/appointments/1
    [HttpGet("{id}")]
    public IActionResult GetAppointment(int id)
    {
        var appointment = _appointmentService.GetAppointmentById(id);

        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        return Ok(appointment);
    }


    // POST: api/appointments
    [HttpPost]
    public IActionResult CreateAppointment(CreateAppointmentDto appointmentDto)
    {
        var appointment = _appointmentService.CreateAppointment(appointmentDto);

        return Ok(appointment);
    }


    // PUT: api/appointments/1
    [HttpPut("{id}")]
    public IActionResult UpdateAppointment(
        int id,
        UpdateAppointmentDto appointmentDto)
    {
        var appointment =
            _appointmentService.UpdateAppointment(id, appointmentDto);

        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        return Ok(appointment);
    }


    // DELETE: api/appointments/1
    [HttpDelete("{id}")]
    public IActionResult DeleteAppointment(int id)
    {
        var result =
            _appointmentService.DeleteAppointment(id);

        if (!result)
        {
            return NotFound("Appointment not found");
        }

        return Ok("Appointment Deleted Successfully");
    }
}