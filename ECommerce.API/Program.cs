using ECommerce.API.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.MapControllers();
    app.MapFallbackToFile("/index.html");
}
app.Run();
