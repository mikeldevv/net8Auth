using Auth.Api.Dto;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Auth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public AuthController(UserManager<ApplicationUser> userManager, IOptionsMonitor<BearerTokenOptions> bearerTokenOptions, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _bearerTokenOptions = bearerTokenOptions;
        _signInManager = signInManager;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Registration successful" });
            }
            else
            {
                var errors = result.Errors.Select(error => error.Description);
                return BadRequest(new { errors });
            }
        }

        return BadRequest(ModelState);
    }
    
    [HttpPost("/login")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Authentication successful, return a success response or redirect
                return Ok(new { message = "Login successful" });
            }
            else
            {
                // Authentication failed, return an error response
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }

        // If ModelState is not valid, return bad request with model validation errors
        return BadRequest(ModelState);
    }

}