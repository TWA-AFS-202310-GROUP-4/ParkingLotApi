using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ParkingLotApi.Filters;
using ParkingLotApi.Repositories;
using ParkingLotApi.Repositories.Interface;
using ParkingLotApi.Services;
using System;
using ParkingLotApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidCapacityExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ParkingLotsService>();
builder.Services.AddSingleton<IParkingLotRepository, ParkingLotRepository>();
builder.Services.Configure<ParkingLotDataBaseSetting>(builder.Configuration.GetSection("ParkingLotStoreDatabase"));


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
{}