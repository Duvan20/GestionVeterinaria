using Microsoft.EntityFrameworkCore;
using GestionVeterinaria.Data;
using GestionVeterinaria.Models;
using GestionVeterinaria.Services.Vets;
using GestionVeterinaria.Services.Pets;
using GestionVeterinaria.Services.Quotes;
using GestionVeterinaria.Services.Owners;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuration Important
builder.Services.AddControllers();


//configuration of the service
builder.Services.AddScoped<IVetsService, VetsService>();
builder.Services.AddScoped<IPetsService,PetsService>();
builder.Services.AddScoped<IQuotesService,QuotesService>();
builder.Services.AddScoped<IOwnersService,OwnerService>();



//database
builder.Services.AddDbContext<GestionVeterinariaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("GestionVeterinariaConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));



var app = builder.Build();

//configuration of  the program 
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
