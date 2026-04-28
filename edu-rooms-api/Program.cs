using edu_rooms_api.Models;
using edu_rooms_api.Services;
using edu_rooms_api.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddSingleton<IList<Room>>(InMemoryData.Rooms);
builder.Services.AddSingleton<IList<Reservation>>(InMemoryData.Reservations);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

InMemoryData.Seed();

app.Run();