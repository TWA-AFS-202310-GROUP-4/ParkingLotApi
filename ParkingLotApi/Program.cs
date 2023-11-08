using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ParkingLotApi.DTOs;
using ParkingLotApi.Exceptions;
using ParkingLotApi.Filters;
using ParkingLotApi.Interfaces;
using ParkingLotApi.Repositories;
using ParkingLotApi.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidCapacityExceptionFilter>();
    options.Filters.Add<InvalidIdOrNameExceptionFilter>();
    options.Filters.Add<RepeatNameExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IMongoClient, MongoClient>();
builder.Services.AddSingleton<IParkingLotRepository, ParkingLotRepository>();
builder.Services.AddScoped<ParkingLotService>();
//bind object model from configuration

//add it to services
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
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

public partial class Program { }