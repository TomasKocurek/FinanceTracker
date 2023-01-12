using FinanceTrackerAPI.Dtos;
using FinanceTrackerAPI.Others;
using FinanceTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly LoginService _loginService;

    public UsersController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] NewUserDto dto)
    {
        await _loginService.AddUser(dto);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<JwtTokenResponse>> LoginUser([FromBody] LoginDto dto)
    {
        return Ok(await _loginService.LoginUser(dto));
    }
}
