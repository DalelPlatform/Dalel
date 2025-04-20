using Dalel.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Dalel.Services.HotelService;
using Dalel.Services;
using Dalel.Services.Agency;
using Models.Agency;
using Dalel.Repository.Agency;
using Serilog;
using Microsoft.OpenApi.Models;
using Models.HomeService;
using Utilities;
using Models.Restaurant;
using Models.HomeChef;
using Models.Property;
using Models.Hotel;
using Models.Driver;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DelelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
// Register AutoMapper

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; //Preserve or ignoreCycle
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Keep property names as they are
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; // Ignore null values
});

builder.Services.AddEndpointsApiExplorer();
//To Enable Swagger to test authentication token >>(Bearer space token)
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddDbContext<DelelContext>
    (i => i.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DelelContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add srilog logging
Log.Logger = new LoggerConfiguration()  
                .ReadFrom.Configuration(builder.Configuration) 
                .WriteTo.Console()                             
                .CreateLogger();                              
                                                     
builder.Host.UseSerilog(); 

#region Account
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AppUserRepository>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<PropertyOwnerReopsitory>();
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
builder.Services.AddScoped<HomeChefDeliveryRepository>();
builder.Services.AddScoped<HomeChefMealRepository>();
builder.Services.AddScoped<HomeChefOrderMealRepository>();
builder.Services.AddScoped<HomeChefOrderRepository>();
builder.Services.AddScoped<PaymentHomeChefOrderRepasitory>();
builder.Services.AddScoped<ReviewHomeChefOrderRepository>();
builder.Services.AddScoped<HomeChefService>();

#endregion

#region HotelServicess
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
#endregion

#region Agency
builder.Services.AddScoped<AgencyPakageService>();
builder.Services.AddScoped<AgencyCustomerInquiry>();
builder.Services.AddScoped<AgencyPackageRepo>();
builder.Services.AddScoped<AgencyPaymentRepo>();
builder.Services.AddScoped<AgencyPromotionRepo>();
builder.Services.AddScoped<AgencyVerificationDocumentRepo>();
builder.Services.AddScoped<PackagebookingRepo>();
builder.Services.AddScoped<PackageBookingReviewRepo>();
builder.Services.AddScoped<PackageSchaduleRepo>();
builder.Services.AddScoped<PackageStepRepo>();
builder.Services.AddScoped<TravelAgenciesRepo>();
#endregion

#region Payment

builder.Services.AddScoped<StripeService>();
builder.Services.AddScoped<PayPalService>();
builder.Services.AddScoped<IPaymentProcessor<PaymentRestaurantOrder>, RestaurantPaymentProcess>();
builder.Services.AddScoped<IPaymentProcessor<PaymentHotelRoom>, HotelPaymentProcess>();
builder.Services.AddScoped<IPaymentProcessor<PaymentProperties>, PropertyPaymentProcess>();
builder.Services.AddScoped<IPaymentProcessor<PaymentHomeChefOrder>, HomeChefPaymentProcess>();
builder.Services.AddScoped<IPaymentProcessor<PackageBookingPayment>, AgencyPaymentProcess>();
builder.Services.AddScoped<IPaymentProcessor<ServiceProviderPayment>, ServiceProviderPaymentProcess>();
builder.Services.AddScoped<IPaymentProcessor<PaymentVehicle>, DriverPaymentProcess>();

#endregion

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
app.UseSwagger();
app.UseSwaggerUI();
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
