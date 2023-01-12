using FinanceTrackerAPI.Dtos;
using FinanceTrackerAPI.Infrastructure.Entities;
using FinanceTrackerAPI.Others;
using FinanceTrackerAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceTrackerAPI.Services;

public class LoginService
{
    private readonly UsersRepository _usersRepository;

    public LoginService(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
    }

    public async Task<JwtTokenResponse> LoginUser(LoginDto dto)
    {
        var user = await _usersRepository.GetUserByEmail(dto.Email);

        if (user is null || !VerifyPassword(dto.Password, user.PasswordHash)) return new();

        SymmetricSecurityKey secretKey = new(Encoding.UTF8.GetBytes(CustomConfigurationManager.AppSettings["JWT:Secret"]));
        SigningCredentials signingCredentials = new(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: CustomConfigurationManager.AppSettings["JWT:ValidIssuer"],
            audience: CustomConfigurationManager.AppSettings["JWT:ValidAudience"],
            claims: new List<Claim>(),
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: signingCredentials
            );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new() { Token = tokenString, Id = user.Id };
    }

    public Task AddUser(NewUserDto dto)
    {
        var hashedPassword = HashPassword(dto.Password);

        User user = new()
        {
            Email = dto.Email,
            Name = dto.Name,
            PasswordHash = hashedPassword,
            Id = Guid.NewGuid().ToString()
        };

        return _usersRepository.CreateUser(user);
    }
}
