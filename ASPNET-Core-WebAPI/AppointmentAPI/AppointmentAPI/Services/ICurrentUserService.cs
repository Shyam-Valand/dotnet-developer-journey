namespace AppointmentAPI.Services;

public interface ICurrentUserService
{
    int UserId { get; }
    string Role { get; }
}