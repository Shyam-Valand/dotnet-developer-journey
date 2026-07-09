using AppointmentAPI.Models;

namespace AppointmentAPI.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetUserWithCustomerAsync(int id);
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<int> CountByRoleAsync(string role);
}