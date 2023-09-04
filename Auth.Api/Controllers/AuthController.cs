using Auth.Api.Dto;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Auth.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public AuthController(UserManager<ApplicationUser> userManager, IOptionsMonitor<BearerTokenOptions> bearerTokenOptions, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _bearerTokenOptions = bearerTokenOptions;
        _signInManager = signInManager;
    }

    [HttpPost("/register")]
    public  Task<IActionResult> Register(RegisterViewModel model)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("/login")]
    public  Task<IActionResult> Login(LoginViewModel model)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("/refresh")]
    public  Task<IActionResult> Refresh()
    {
        throw new NotImplementedException();
    }

}