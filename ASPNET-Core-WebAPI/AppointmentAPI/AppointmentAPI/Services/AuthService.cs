using AppointmentAPI.DTOs;
using AppointmentAPI.Exceptions;
using AppointmentAPI.Models;
using AppointmentAPI.Repositories;

namespace AppointmentAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository,IPasswordService passwordService,IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            throw new BadRequestException(
                "Email already registered"
            );
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = _passwordService.HashPassword(dto.Password),
            Role = dto.Role
        };
        await _userRepository.AddAsync(user);

        return new AuthResponseDto
        {
            Email = user.Email,
            Role = user.Role,
            Token = _jwtService.GenerateToken(user)
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null)
        {
            throw new BadRequestException(
                "Invalid email or password"
            );
        }

        var validPassword = _passwordService.VerifyPassword(dto.Password,user.PasswordHash);

        if (!validPassword)
        {
            throw new BadRequestException(
                "Invalid email or password"
            );
        }

        return new AuthResponseDto
        {
            Email = user.Email,
            Role = user.Role,
            Token = _jwtService.GenerateToken(user)
        };
    }
}