using AppointmentAPI.DTOs;
using AppointmentAPI.Models;
using AppointmentAPI.Repositories;

namespace AppointmentAPI.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;


    public AppointmentService(
        IAppointmentRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<AppointmentDto>> GetAllAppointments()
    {
        var appointments =
            await _repository.GetAll();


        return appointments.Select(x => new AppointmentDto
        {
            Id = x.Id,
            CustomerName = x.Customer!.Name,
            ServiceName = x.Service!.Name,
            AppointmentDate = x.AppointmentDate,
            Status = x.Status

        }).ToList();
    }


    public async Task<AppointmentDto?> GetAppointmentById(int id)
    {
        var appointment =
            await _repository.GetById(id);


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


    public async Task<Appointment> CreateAppointment(
        CreateAppointmentDto dto)
    {
        if (dto.AppointmentDate < DateTime.Now)
        {
            throw new Exception(
                "Appointment date cannot be in the past"
            );
        }


        bool exists =
            await _repository.Exists(
                dto.ServiceId,
                dto.AppointmentDate
            );


        if (exists)
        {
            throw new Exception(
                "This appointment slot is already booked"
            );
        }


        var appointment = new Appointment
        {
            CustomerId = dto.CustomerId,
            ServiceId = dto.ServiceId,
            AppointmentDate = dto.AppointmentDate,
            Status = "Booked"
        };


        await _repository.Add(appointment);

        await _repository.Save();


        return appointment;
    }


    public async Task<Appointment?> UpdateAppointment(
        int id,
        UpdateAppointmentDto dto)
    {
        var appointment =
            await _repository.GetById(id);


        if (appointment == null)
            return null;


        appointment.AppointmentDate =
            dto.AppointmentDate;

        appointment.Status =
            dto.Status;


        await _repository.Save();


        return appointment;
    }


    public async Task<bool> DeleteAppointment(int id)
    {
        var appointment =
            await _repository.GetById(id);


        if (appointment == null)
            return false;


        _repository.Delete(appointment);


        await _repository.Save();


        return true;
    }
}