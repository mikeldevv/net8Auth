using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql("Server=localhost;Port=5433;Database=AuthDb;Username=postgres;Password=");
});

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();
app.Run();


class ApplicationUser : IdentityUser
{
}

class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}