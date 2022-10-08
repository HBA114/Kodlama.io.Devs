using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        AuthRegisterCommand registerCommand = new()
        {
            UserForRegisterDto = userForRegisterDto,
            IPAddress = GetIPAddress()
        };

        RegisteredDto result = await Mediator.Send(registerCommand);
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created("", result.AccessToken);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        AuthLoginCommand authLoginCommand = new()
        {
            UserForLoginDto = userForLoginDto,
            IPAddress = GetIPAddress()
        };

        LoggedInDto result = await Mediator.Send(authLoginCommand);
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created("Logged In", result.AccessToken);
    }

    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }
}