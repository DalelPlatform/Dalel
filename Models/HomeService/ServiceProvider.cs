using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class ServiceProvider : AspNetUser
    {
        public string Image { get; set; }
        public List<string> Skills { get; set; } = new List<string>();
        public DateTime StartProfisionalAt { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public string About { get; set; }
        public string Licence { get; set; }
        public string Certificate { get; set; }
        public int CategoryServicesId { get; set; }
        public virtual CategoryServices CategoryServices { get; set; }
        public virtual ICollection<ServiceProviderProject> Projects { get; set; } = new List<ServiceProviderProject>();
        public virtual ICollection<ServiceProviderBooking> Bookings { get; set; } = new List<ServiceProviderBooking>();
        public virtual ICollection<ServiceProviderReview> Reviews { get; set; } = new List<ServiceProviderReview>();
    }
    public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.Image)
                .HasMaxLength(255);

            builder.Property(sp => sp.About)
                .HasMaxLength(1000);

            builder.Property(sp => sp.Licence)
                .HasMaxLength(50);

            builder.Property(sp => sp.Certificate)
                .HasMaxLength(50);

            builder.HasOne(sp => sp.CategoryServices)
                .WithMany(cs => cs.ServiceProviders)
                .HasForeignKey(sp => sp.CategoryServicesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sp => sp.Projects)
                .WithOne(pp => pp.ServiceProvider)
                .HasForeignKey(pp => pp.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sp => sp.Bookings)
                .WithOne(sb => sb.ServiceProvider)
                .HasForeignKey(sb => sb.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sp => sp.Reviews)
                .WithOne(sr => sr.ServiceProvider)
                .HasForeignKey(sr => sr.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new ServiceProvider
                {
                    Image = "image1.jpg",
                    Skills = new List<string> { "Plumbing", "Pipe Fitting" },
                    StartProfisionalAt = DateTime.Now,
                    AvailableFrom = DateTime.Now,
                    AvailableTo = DateTime.Now.AddHours(8),
                    About = "Experienced plumber",
                    Licence = "LIC123",
                    Certificate = "CERT123",
                    CategoryServicesId = 1
                }
            );
        }
    }

}
