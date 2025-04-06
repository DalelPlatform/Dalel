using Dalel.Repository;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Dalel.Services.HotelService;
using FluentValidation.AspNetCore;
using FluentValidation;
using Models.Hotel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
// Enable automatic FluentValidation integration and scan for
// validators in the assembly

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


// Register Repositories
builder.Services.AddScoped<BookingHotelRoomRepository>();
builder.Services.AddScoped<HotelRepository>();
builder.Services.AddScoped<RoomTypeRepository>();

// Register Services
builder.Services.AddScoped<IBookingHotelRoomService, BookingHotelRoomService>();
builder.Services.AddScoped<IHotelService, Dalel.Services.HotelService.HotelService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
// Add this to your Program.cs

app.MapControllers();

app.Run();
