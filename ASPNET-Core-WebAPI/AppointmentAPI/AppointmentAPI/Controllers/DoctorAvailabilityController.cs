using AppointmentAPI.DTOs;
using AppointmentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[Authorize(Roles = "Doctor")]
[Route("api/[controller]")]
[ApiController]
public class DoctorAvailabilityController : ControllerBase
{
    private readonly IDoctorAvailabilityService _service;

    public DoctorAvailabilityController(IDoctorAvailabilityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyAvailability()
    {
        var availability = await _service.GetMyAvailabilityAsync();

        return Ok(
            new ApiResponse<List<DoctorAvailabilityDto>>(true, "Availability fetched successfully", availability)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAvailability(CreateDoctorAvailabilityDto dto)
    {
        var availability = await _service.CreateAvailabilityAsync(dto);

        return Ok(
            new ApiResponse<DoctorAvailabilityDto>(true, "Availability created successfully", availability)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAvailability(int id)
    {
        var result = await _service.DeleteAvailabilityAsync(id);

        if (!result)
        {
            return NotFound(
                new ApiResponse<string>(false, "Availability not found", null)
            );
        }

        return Ok(
            new ApiResponse<string>(true, "Availability deleted successfully", null)
        );
    }
}