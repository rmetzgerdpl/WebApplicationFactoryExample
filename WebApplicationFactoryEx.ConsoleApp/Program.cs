using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApplicationFactoryEx.ConsoleApp.DataStore;
using WebApplicationFactoryEx.ConsoleApp.Managers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nebraska.Code", Version = "v1" });
});

builder.Services.AddDbContext<DbContext>(options =>
{
    options.UseSqlServer("ConnectionString");
});

builder.Services.AddScoped<IWeatherManager, WeatherManager>();
builder.Services.AddScoped<IDataStore, WeatherDataStore>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplicationFactoryExample v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

public partial class Program { }