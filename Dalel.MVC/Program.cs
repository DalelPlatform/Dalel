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
//DI 
builder.Services.AddScoped(typeof(PackagebookingRepo));
builder.Services.AddScoped(typeof(AgencyPackageRepo));
builder.Services.AddScoped(typeof(AgencyPaymentRepo));
builder.Services.AddScoped(typeof(AgencyPromotionRepo));


var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
