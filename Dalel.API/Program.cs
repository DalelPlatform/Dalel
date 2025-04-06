using Dalel.Repository;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DelelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();

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
