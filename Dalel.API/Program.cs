using Dalel.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.User;
using Dalel.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.User;
using System.Text;
using System.Text.Json.Serialization;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Dalel.Services.HotelService;
using FluentValidation.AspNetCore;
using FluentValidation;
using Models.Hotel;
using Dalel.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DelelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(HotelMappingProfile));

builder.Services.AddControllers();
builder.Services.AddDbContext<DelelContext>
    (i => i.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DelelContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AppUserRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<DriverRepository>();
builder.Services.AddScoped<HomeChefReopsitory>();
builder.Services.AddScoped<HotelOwnerReopsitory>();
builder.Services.AddScoped<PropertiesRepository>();
builder.Services.AddScoped<RestaurantOwnerReopsitory>();
builder.Services.AddScoped<ServiceProviderRepository>();
builder.Services.AddScoped<TravelAgencyOwnerReopsitory>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.MaxDepth = 64;
    });

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    //on One Statless Request
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:PrivateKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// Add this to your Program.cs

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{area=admin}/{controller=Home}/{action=Index}");

app.MapControllers();

app.Run();
