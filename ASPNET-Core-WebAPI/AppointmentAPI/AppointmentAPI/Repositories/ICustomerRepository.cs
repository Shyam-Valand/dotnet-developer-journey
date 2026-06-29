using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
}