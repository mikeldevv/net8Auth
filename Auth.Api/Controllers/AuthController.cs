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

    public AuthController(UserManager<ApplicationUser> userManager, IOptionsMonitor<BearerTokenOptions> bearerTokenOptions)
    {
        _userManager = userManager;
        _bearerTokenOptions = bearerTokenOptions;
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
}