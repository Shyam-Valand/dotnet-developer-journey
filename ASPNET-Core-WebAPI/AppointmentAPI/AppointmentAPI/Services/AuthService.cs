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
    private readonly ICustomerRepository _customerRepository;

    public AuthService(IUserRepository userRepository, IPasswordService passwordService, IJwtService jwtService, ICustomerRepository customerRepository)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtService = jwtService;
        _customerRepository = customerRepository;
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
        Customer? customer = null;

        if (dto.Role == "Patient")
        {
            customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _customerRepository.AddAsync(customer);
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = _passwordService.HashPassword(dto.Password),
            Role = dto.Role,
            CustomerId = customer?.Id
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

        var validPassword = _passwordService.VerifyPassword(dto.Password, user.PasswordHash);

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