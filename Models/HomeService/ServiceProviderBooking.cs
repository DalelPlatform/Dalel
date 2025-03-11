using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeService.ENUMS;

namespace Models.HomeService
{
    public class ServiceProviderBooking
    {
        public int Id { get; set; }
        public int ServiceProviderId { get; set; }
        public int ClientId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingTime { get; set; }
        public BookingStatus Status { get; set; }
        public string BookingType { get; set; }
        public string BookingDescription { get; set; }
        public string BookingAddress { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual ICollection<ServiceProviderReview> Reviews { get; set; } = new List<ServiceProviderReview>();
        public virtual ICollection<ServiceProviderPayment> Payments { get; set; } = new List<ServiceProviderPayment>();
    }
    public class ServiceProviderBookingConfiguration : IEntityTypeConfiguration<ServiceProviderBooking>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderBooking> builder)
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
        }
    }
}
