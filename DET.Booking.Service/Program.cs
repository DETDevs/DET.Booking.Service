using DET.Booking.BusinessLogic.Extensions;
using DET.Booking.Extensions;
using DET.Booking.Service.Worker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DET.Booking.DataAccess.Interfaces.IConnectionManager, DET.Booking.DataAccess.ConnectionManager>();
builder.Services.AddScoped<DET.Booking.DataAccess.Interfaces.IService, DET.Booking.DataAccess.Service>();
builder.Services.AddScoped<DET.Booking.BusinessLogic.Interfaces.IService, DET.Booking.BusinessLogic.Service>();

builder.Services.AddScoped<DET.Booking.DataAccess.Interfaces.IBooking, DET.Booking.DataAccess.Booking>();
builder.Services.AddScoped<DET.Booking.BusinessLogic.Interfaces.IBooking, DET.Booking.BusinessLogic.Booking>();

builder.Services.AddScoped<DET.Booking.BusinessLogic.Extensions.EmailService>();

builder.Services.AddScoped<CustomValuesConfiguration>();

//builder.Services.AddHostedService<ReservaReminderService>(); // Descomentar para activar el worker de recordatorio de reservas
builder.Services.AddScoped<WhatsAppService>();

// Añadir servicios de SignalR
builder.Services.AddSignalR();
builder.Services.AddSingleton<NotificacionService>();

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

app.MapHub<NotificacionHub>("/hub/notificaciones"); // Ruta del Hub

app.Run();
