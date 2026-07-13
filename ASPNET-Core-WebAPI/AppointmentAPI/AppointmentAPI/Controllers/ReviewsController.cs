using AppointmentAPI.DTOs;
using AppointmentAPI.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers;

[ApiVersion("1.0")]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // POST: api/reviews/appointment/1
    [Authorize(Roles = "Patient")]
    [HttpPost("appointment/{appointmentId}")]
    public async Task<IActionResult> CreateReview(int appointmentId, CreateReviewDto dto)
    {
        var review = await _reviewService.CreateReviewAsync(appointmentId, dto);

        return Ok(
            new ApiResponse<ReviewDto>
            (
                true,
                "Review submitted successfully.",
                review
            )
        );
    }

    // GET: api/reviews/doctor/2
    [AllowAnonymous]
    [HttpGet("doctor/{doctorId}")]
    public async Task<IActionResult> GetDoctorReviews(int doctorId)
    {
        var reviews = await _reviewService.GetDoctorReviewsAsync(doctorId);

        return Ok(
            new ApiResponse<List<ReviewDto>>
            (
                true,
                "Doctor reviews fetched successfully.",
                reviews
            )
        );
    }

    // GET: api/reviews/doctor/2/average-rating
    [AllowAnonymous]
    [HttpGet("doctor/{doctorId}/average-rating")]
    public async Task<IActionResult> GetDoctorAverageRating(int doctorId)
    {
        var average = await _reviewService.GetDoctorAverageRatingAsync(doctorId);

        return Ok(
            new ApiResponse<double>
            (
                true,
                "Doctor average rating fetched successfully.",
                average
            )
        );
    }
}