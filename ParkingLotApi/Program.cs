using ParkingLotApi.Filters;
using ParkingLotApi.Repositories;
using ParkingLotApi.Services;
using ParkingLotApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add<InvalidCapacityExceptionFilter>(); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IParkingLotsRepository, ParkingLotsRepository>();
builder.Services.AddScoped<ParkingLotsService>();
builder.Services.Configure<ParkingLotDatabaseSetting>(
    builder.Configuration.GetSection("ParkingLotStoreDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{

}