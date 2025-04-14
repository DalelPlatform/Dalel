using Dalel.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.User;
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
using Models.Hotel;
using Dalel.Mappings;
using Dalel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DelelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
// Register AutoMapper

builder.Services.AddControllers();
builder.Services.AddDbContext<DelelContext>
    (i => i.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DelelContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Account
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AppUserRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<DriverRepository>();
builder.Services.AddScoped<HomeChefReopsitory>();
builder.Services.AddScoped<HotelOwnerReopsitory>();
builder.Services.AddScoped<RestaurantOwnerReopsitory>();
builder.Services.AddScoped<ServiceProviderRepository>();
builder.Services.AddScoped<TravelAgencyOwnerReopsitory>();
#endregion

#region Serviceprovider
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
builder.Services.AddScoped<ServiceProviderProjectRepository>();
builder.Services.AddScoped<ServiceProviderPropsalRepository>();
builder.Services.AddScoped<ServiceProviderScheduleRepository>();
#endregion

#region Property
builder.Services.AddScoped<PropertyService>();
builder.Services.AddScoped<PropertiesRepository>();
builder.Services.AddScoped<BookingPropertiesRepository>();
builder.Services.AddScoped<PaymentPropertiesRepository>();
builder.Services.AddScoped<ReviewPropertiesRepository>();
#endregion

#region Restaurant
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<MealService>();
builder.Services.AddScoped<RestaurantRepository>();
builder.Services.AddScoped<RestaurantMenuItemRepository>();
builder.Services.AddScoped<RestaurantOrderRepository>();
#endregion

#region HomeChef

//builder.Services.AddScoped<HomeChefDeliveryRepository>();
//builder.Services.AddScoped<HomeChefMealRepository>();
//builder.Services.AddScoped<HomeChefOrderMealRepository>();
//builder.Services.AddScoped<HomeChefOrderRepository>();
//builder.Services.AddScoped<PaymentHomeChefOrderRepasitory>();
//builder.Services.AddScoped<ReviewHomeChefOrderRepository>();

#endregion

// Register repository classes (Scoped lifetime is recommended)
builder.Services.AddScoped<BookingHotelRoomRepository>();
builder.Services.AddScoped<HotelRepository>();
builder.Services.AddScoped<RoomTypeRepository>();
builder.Services.AddScoped<PaymentHotelRoomRepository>();
builder.Services.AddScoped<BookingGuestInRoomRepository>(); // if you use it in services

// Register service classes using interfaces
builder.Services.AddScoped<IBookingHotelRoomService, BookingHotelRoomService>();
builder.Services.AddScoped<IHotelService, Dalel.Services.HotelService.HotelService>();
builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
builder.Services.AddScoped<IPaymentHotelRoomService, PaymentHotelRoomService>();
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
