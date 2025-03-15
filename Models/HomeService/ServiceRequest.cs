using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeService.ENUMS;
using Models.User;

namespace Models.HomeService
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public BookingStatus Status { get; set; }
        public double StartPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? Image { get; set; }
        public virtual Client Client { get; set; }
        //relation with cat

        public virtual ICollection<ServiceProviderPropsal> Propsals { get; set; } 
        public virtual ServiceProviderReview Review { get; set; }
        public virtual ServiceProviderPayment Payment { get; set; } 
    }
    public class ServiceProviderBookingConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.HasKey(sb => sb.Id);
            builder.Property(sb => sb.BookingType)
                .HasMaxLength(50);
            builder.Property(sb => sb.BookingDescription)
                .HasMaxLength(1000);
            builder.Property(sb => sb.BookingAddress)
                .HasMaxLength(255);
            builder.HasOne(sb => sb.ServiceProvider)
                .WithMany(sp => sp.Bookings)
                .HasForeignKey(sb => sb.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(sb => sb.Reviews)
                .WithOne(sr => sr.ServiceProviderBooking)
                .HasForeignKey(sb => sb.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(sb => sb.Payments)
                .WithOne(sp => sp.ServiceProviderBooking)
                .HasForeignKey(sb => sb.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sb => sb.Client)
                .WithMany(c => c.serviceProviderBookings)
                .HasForeignKey(sb => sb.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
