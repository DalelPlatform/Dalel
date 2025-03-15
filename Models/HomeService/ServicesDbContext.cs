using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.HomeService;
using System;
using System.Collections.Generic;

public class ServicesDbContext : DbContext
{
    public DbSet<CategoryServices> CategoryServices { get; set; }
    public DbSet<ServiceProvider> ServiceProviders { get; set; }
    public DbSet<ServiceProviderBooking> ServiceProviderBookings { get; set; }
    public DbSet<ServiceProviderPayment> ServiceProviderPayments { get; set; }
    public DbSet<ServiceProviderProject> ServiceProviderProjects { get; set; }
    public DbSet<ServiceProviderReview> ServiceProviderReviews { get; set; }
    public DbSet<ServiceQuaries> ServiceQuaries { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=REEM-ASHRAF ;Database=Services;User Id = Reem Ashraf; Password =;Integrated security = True; Trusted_Connection=True;TrustserverCertificate = True;");
    }
}
