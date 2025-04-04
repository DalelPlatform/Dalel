using Dalel.Repository;
using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DelelContext>(i =>
i.UseLazyLoadingProxies()
.UseSqlServer(builder.Configuration.GetConnectionString("DalelDB")));
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<DelelContext>();

//Agency Repos
builder.Services.AddScoped(typeof(PackagebookingRepo));
builder.Services.AddScoped(typeof(AgencyPackageRepo));
builder.Services.AddScoped(typeof(AgencyPaymentRepo));
builder.Services.AddScoped(typeof(AgencyPromotionRepo));

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
builder.Services.AddScoped(typeof(CategoryServicesRepository));


var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
