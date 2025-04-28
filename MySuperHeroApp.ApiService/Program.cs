using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySuperHeroApp.ApiService.Api;
using MySuperHeroApp.ApiService.Database;
using MySuperHeroApp.ApiService.Jobs.Core;
using MySuperHeroApp.ApiService.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.Services.AddDbContext<SuperHeroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddHostedService<JobWorker>();
builder.Services.AddSingleton<ITaskQueue, TaskQueue>();
builder.Services.AddScoped<IAddSuperHeroTask,AddSuperHeroTask>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

//add weather forecast endpoints here
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast(
        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        Random.Shared.Next(-20, 55),
        "Sunny"
    )).ToArray();
    return forecast;
});

app.MapDefaultEndpoints();
app.MapSuperHeroEndpoints();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
