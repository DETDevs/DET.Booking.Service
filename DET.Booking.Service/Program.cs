var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DET.Booking.DataAccess.Interfaces.IConnectionManager, DET.Booking.DataAccess.ConnectionManager>();
builder.Services.AddScoped<DET.Booking.DataAccess.Interfaces.IService, DET.Booking.DataAccess.Service>();
builder.Services.AddScoped<DET.Booking.BusinessLogic.Interfaces.IService, DET.Booking.BusinessLogic.Service>();

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
