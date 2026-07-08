using AppointmentAPI.DTOs;
using AppointmentAPI.Exceptions;
using AppointmentAPI.Models;
using AppointmentAPI.Repositories;

namespace AppointmentAPI.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly ICurrentUserService _currentUserService;

    public ReviewService(
        IReviewRepository reviewRepository,
        ICurrentUserService currentUserService)
    {
        _reviewRepository = reviewRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ReviewDto> CreateReviewAsync(int appointmentId, CreateReviewDto dto)
    {
        var appointment = await _reviewRepository.GetCompletedAppointmentAsync(appointmentId);

        if (appointment == null)
            throw new NotFoundException("Completed appointment not found");

        if (appointment.UserId != _currentUserService.UserId)
            throw new BadRequestException("You can review only your own appointments");

        var existingReview = await _reviewRepository.GetByAppointmentIdAsync(appointmentId);

        if (existingReview != null)
            throw new BadRequestException("Review already submitted");

        var review = new Review
        {
            AppointmentId = appointmentId,
            Rating = dto.Rating,
            Comment = dto.Comment
        };

        await _reviewRepository.AddAsync(review);
        await _reviewRepository.SaveAsync();

        return new ReviewDto
        {
            Id = review.Id,
            PatientName = appointment.Customer!.Name,
            DoctorName = appointment.Doctor!.Name,
            Rating = review.Rating,
            Comment = review.Comment,
            AppointmentDate = appointment.AppointmentDate
        };
    }

    public async Task<List<ReviewDto>> GetDoctorReviewsAsync(int doctorId)
    {
        var reviews = await _reviewRepository.GetDoctorReviewsAsync(doctorId);

        return reviews.Select(r => new ReviewDto
        {
            Id = r.Id,
            PatientName = r.Appointment!.Customer!.Name,
            DoctorName = r.Appointment.Doctor!.Name,
            Rating = r.Rating,
            Comment = r.Comment,
            AppointmentDate = r.Appointment.AppointmentDate
        }).ToList();
    }

    public async Task<double> GetDoctorAverageRatingAsync(int doctorId)
    {
        return await _reviewRepository.GetDoctorAverageRatingAsync(doctorId);
    }
}