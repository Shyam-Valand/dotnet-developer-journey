using System.Security.Claims;

namespace AppointmentAPI.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UserId
    {
        get
        {
            var id = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Convert.ToInt32(id);
        }
    }

    public string Role
    {
        get
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value ?? "";
        }
    }
}