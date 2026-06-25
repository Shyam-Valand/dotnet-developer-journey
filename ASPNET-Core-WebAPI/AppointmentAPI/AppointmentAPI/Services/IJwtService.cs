using AppointmentAPI.Models;

namespace AppointmentAPI.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}