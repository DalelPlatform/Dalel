using Dalel.Repository;
using Dalel.Repository.Agency;
using Dalel.Repository.HomeServices;
using Dalel.Services;
using Dalel.Services.Agency;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Agency;
using Models.User;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DelelContext>(i =>
i.UseLazyLoadingProxies()
.UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DelelContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(RoleRepository));

//Agency Repos
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

//Restaurant Repos
builder.Services.AddScoped(typeof(RestaurantRepository));
builder.Services.AddScoped(typeof(PaymentRestaurantOrderReopsitory));
builder.Services.AddScoped(typeof(RestaurantMenuItemRepository));
builder.Services.AddScoped(typeof(RestaurantOrderRepository));
builder.Services.AddScoped(typeof(RestaurantOrderItemRepository));
builder.Services.AddScoped(typeof(RestaurantReservationRepository));
builder.Services.AddScoped(typeof(ReviewRestaurantOrderRepository));

//Property Repos
builder.Services.AddScoped(typeof(PropertiesRepository));
builder.Services.AddScoped(typeof(BookingPropertiesRepository));
builder.Services.AddScoped(typeof(PaymentPropertiesRepository));
builder.Services.AddScoped(typeof(ReviewPropertiesRepository));


//HomeServices
builder.Services.AddScoped<HomeServiceRepository>();
builder.Services.AddScoped<Services>();

builder.Services.AddScoped(typeof(BaseRepository<>));
builder.Services.AddScoped<PendingRequestService>();



var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=CategoryController}/{action=Index}");


app.MapGet("/test", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();
