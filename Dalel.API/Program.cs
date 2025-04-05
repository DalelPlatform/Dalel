using Dalel.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
// Add this to your Program.cs
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
app.MapControllers();

app.Run();
