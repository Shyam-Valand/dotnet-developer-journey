    using AppointmentAPI.DTOs;
    using AppointmentAPI.Models;
    using AppointmentAPI.Repositories;
    using AppointmentAPI.Exceptions;

    namespace AppointmentAPI.Services;

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public AppointmentService(IAppointmentRepository repository,ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
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
                Status = x.Status
            }).ToList();
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
                return null;

            return new AppointmentDto
            {
                Id = appointment.Id,
                CustomerName = appointment.Customer!.Name,
                ServiceName = appointment.Service!.Name,
                AppointmentDate = appointment.AppointmentDate,
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

            var appointment = new Appointment
            {
                UserId = _currentUserService.UserId,
                CustomerId = dto.CustomerId,
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
                Status = createdAppointment.Status
            };
        }

        public async Task<AppointmentDto?> UpdateAppointmentAsync(int id,UpdateAppointmentDto dto)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
            {
                throw new NotFoundException(
                    "Appointment not found"
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
                Status = appointment.Status
            };
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null)
                return false;

            _repository.Delete(appointment);
            await _repository.SaveAsync();

            return true;
        }
    }