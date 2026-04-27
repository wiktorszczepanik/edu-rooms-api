using edu_rooms_api.DTOs;
using edu_rooms_api.Models;
using edu_rooms_api.Services;
using edu_rooms_api.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<RoomService>();
builder.Services.AddSingleton<IList<Room>>(InMemoryData.Rooms);
builder.Services.AddSingleton<IList<Reservation>>(InMemoryData.Reservations);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

InMemoryData.Seed();

app.Run();