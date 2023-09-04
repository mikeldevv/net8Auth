using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();