using Auth.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("/register")]
    public Task<IActionResult> Register(RegisterViewModel model)
    {
        throw new NotImplementedException();
    }

    [HttpPost("/login")]
    public Task<IActionResult> Login(LoginViewModel model)
    {
        throw new NotImplementedException();
    }

    [HttpPost("/refresh")]
    public Task<IActionResult> Refresh()
    {
        throw new NotImplementedException();
    }

    [HttpGet("/confirmEmail")]
    public Task<IActionResult> ConfirmEmail()
    {
        throw new NotImplementedException();
    }

    [HttpPost("/resendConfirmationEmail")]
    public Task<IActionResult> ResendConfirmationEmail()
    {
        throw new NotImplementedException();
    }

    [HttpPost("/resetPassword")]
    public Task<IActionResult> ResetPassword()
    {
        throw new NotImplementedException();
    }

    [HttpGet("/2fa")]
    public Task<IActionResult> GetTwoFactorAuthentication()
    {
        throw new NotImplementedException();
    }

    [HttpPost("/2fa")]
    public Task<IActionResult> PostTwoFactorAuthentication()
    {
        throw new NotImplementedException();
    }

    [HttpGet("/info")]
    public Task<IActionResult> GetInfo()
    {
        throw new NotImplementedException();
    }

    [HttpPost("/info")]
    public Task<IActionResult> PostInfo()
    {
        throw new NotImplementedException();
    }
}