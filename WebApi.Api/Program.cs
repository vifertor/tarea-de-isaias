using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Interface;
using WebApi.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddScoped<IVacunaService, VacunaService>(); // Registrar el servicio

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
app.UseRouting();
app.MapControllers();


app.Run();