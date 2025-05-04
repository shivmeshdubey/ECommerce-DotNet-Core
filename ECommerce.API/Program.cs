using ECommerce.Application.Services.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);

// JWT Auth




var app = builder.Build();
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.MapControllers();
    app.MapFallbackToFile("/index.html");

}
app.Run();

