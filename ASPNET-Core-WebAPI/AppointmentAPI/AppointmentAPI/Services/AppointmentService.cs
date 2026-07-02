using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using AppointmentAPI.Repositories;
using AppointmentAPI.Exceptions;

namespace AppointmentAPI.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;

    public AppointmentService(IAppointmentRepository repository, ICurrentUserService currentUserService, IUserRepository userRepository)
    {
        _repository = repository;
        _currentUserService = currentUserService;
        _userRepository = userRepository;
    }

    public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _repository.GetByUserIdAsync(_currentUserService.UserId);

        return appointments.Select(x => new AppointmentDto
        {
            Id = x.Id,
            CustomerName = x.Customer!.Name,
            ServiceName = x.Service!.Name,
            AppointmentDate = x.AppointmentDate,
            DoctorName = x.Doctor?.Name,
            Status = x.Status
        }).ToList();
    }

    public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
    {
        var appointment = await _repository.GetByIdAsync(id);

        if (appointment == null)
        {
            throw new NotFoundException("Appointment not found");
        }

        if (appointment.UserId != _currentUserService.UserId)
        {
            throw new BadRequestException("You are not authorized to access this appointment");
        }

        return new AppointmentDto
        {
            Id = appointment.Id,
            CustomerName = appointment.Customer!.Name,
            ServiceName = appointment.Service!.Name,
            AppointmentDate = appointment.AppointmentDate,
            DoctorName = appointment.Doctor?.Name,
            Status = appointment.Status
        };
    }

    public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto dto)
    {
        if (dto.AppointmentDate < DateTime.Now)
        {
            throw new BadRequestException("Appointment date cannot be in the past");
        }

        var serviceDuration = await _repository.GetServiceDurationAsync(dto.ServiceId);
        var appointmentEndTime = dto.AppointmentDate.AddMinutes(serviceDuration);
        bool overlap = await _repository.HasOverlappingAppointmentAsync(
                dto.ServiceId,
                dto.AppointmentDate,
                appointmentEndTime
            );

        if (overlap)
        {
            throw new BadRequestException(
                "Appointment time overlaps with existing booking"
            );
        }

        var user = await _userRepository.GetUserWithCustomerAsync(_currentUserService.UserId);

        if (user == null || user.CustomerId == null)
        {
            throw new BadRequestException("Customer profile not found.");
        }

        var appointment = new Appointment
        {
            UserId = user.Id,
            CustomerId = user.CustomerId.Value,
            ServiceId = dto.ServiceId,
            AppointmentDate = dto.AppointmentDate,
            Status = "Booked"
        };

        await _repository.AddAsync(appointment);
        await _repository.SaveAsync();

        var createdAppointment = await _repository.GetByIdAsync(appointment.Id);

        return new AppointmentDto
        {
            Id = createdAppointment!.Id,
            CustomerName = createdAppointment.Customer!.Name,
            ServiceName = createdAppointment.Service!.Name,
            AppointmentDate = createdAppointment.AppointmentDate,
            DoctorName = createdAppointment.Doctor?.Name,
            Status = createdAppointment.Status
        };
    }

    public async Task<AppointmentDto?> UpdateAppointmentAsync(int id, UpdateAppointmentDto dto)
    {
        var appointment = await _repository.GetByIdAsync(id);

        if (appointment == null)
        {
            throw new NotFoundException(
                "Appointment not found"
            );
        }

        if (appointment.UserId != _currentUserService.UserId)
        {
            throw new BadRequestException(
                "You are not authorized to update this appointment"
            );
        }

        if (dto.AppointmentDate < DateTime.Now)
        {
            throw new BadRequestException(
                "Appointment date cannot be in the past"
            );
        }

        var serviceDuration = await _repository.GetServiceDurationAsync(appointment.ServiceId);

        var appointmentEndTime = dto.AppointmentDate.AddMinutes(serviceDuration);
        bool overlap = await _repository.HasOverlappingAppointmentAsync(
                appointment.ServiceId,
                dto.AppointmentDate,
                appointmentEndTime,
                appointment.Id
            );

        if (overlap)
        {
            throw new BadRequestException(
                "Appointment time overlaps with existing booking"
            );
        }
        appointment.AppointmentDate = dto.AppointmentDate;
        appointment.Status = dto.Status;
        await _repository.SaveAsync();

        return new AppointmentDto
        {
            Id = appointment.Id,
            CustomerName = appointment.Customer!.Name,
            ServiceName = appointment.Service!.Name,
            AppointmentDate = appointment.AppointmentDate,
            DoctorName = appointment.Doctor?.Name,
            Status = appointment.Status
        };
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        var appointment = await _repository.GetByIdAsync(id);

        if (appointment == null)
        {
            throw new NotFoundException(
                "Appointment not found"
            );
        }

        if (appointment.UserId != _currentUserService.UserId)
        {
            throw new BadRequestException(
                "You are not authorized to delete this appointment"
            );
        }

        _repository.Delete(appointment);
        await _repository.SaveAsync();

        return true;
    }

    public async Task AssignDoctorAsync(int appointmentId, AssignDoctorDto dto)
    {
        var appointment = await _repository.GetByIdAsync(appointmentId);

        if (appointment == null)
        {
            throw new NotFoundException("Appointment not found");
        }

        var doctor = await _userRepository.GetByIdAsync(dto.DoctorId);

        if (doctor == null)
        {
            throw new NotFoundException("Doctor not found");
        }

        if (doctor.Role != "Doctor")
        {
            throw new BadRequestException("Selected user is not a doctor");
        }

        appointment.DoctorId = doctor.Id;
        await _repository.SaveAsync();
    }

    public async Task<List<AppointmentDto>> GetDoctorAppointmentsAsync()
    {
        var appointments = await _repository.GetByDoctorIdAsync(_currentUserService.UserId);

        return appointments.Select(x => new AppointmentDto
        {
            Id = x.Id,
            CustomerName = x.Customer!.Name,
            ServiceName = x.Service!.Name,
            AppointmentDate = x.AppointmentDate,
            DoctorName = x.Doctor?.Name,
            Status = x.Status
        }).ToList();
    }
}