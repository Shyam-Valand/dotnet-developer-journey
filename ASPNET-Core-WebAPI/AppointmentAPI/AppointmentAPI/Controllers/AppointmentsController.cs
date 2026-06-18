using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public AppointmentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/appointments
    [HttpGet]
    public IActionResult GetAppointments()
    {
        var appointments = _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .ToList();

        return Ok(appointments);
    }

    // GET: api/appointments/1
    [HttpGet("{id}")]
    public IActionResult GetAppointment(int id)
    {
        var appointment = _context.Appointments
            .Include(x => x.Customer)
            .Include(x => x.Service)
            .FirstOrDefault(x => x.Id == id);

        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    // POST: api/appointments
    [HttpPost]
    public IActionResult CreateAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();

        return Ok(appointment);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAppointment(
    int id,
    Appointment updatedAppointment)
    {
        var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
        if (appointment == null)
        {
            return NotFound();
        }

        appointment.AppointmentDate = updatedAppointment.AppointmentDate;
        appointment.Status = updatedAppointment.Status;
        _context.SaveChanges();

        return Ok(appointment);
    }

    // DELETE: api/appointments/1
    [HttpDelete("{id}")]
    public IActionResult DeleteAppointment(int id)
    {
        var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);

        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();

        return Ok("Appointment Deleted Successfully");
    }
}