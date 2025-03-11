using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Property.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class ServiceProviderPayment
    {
        public int Id { get; set; }
        public PaymentType Payment { get; set; }
        public int BookingId { get; set; }
        public virtual ServiceProviderBooking ServiceProviderBooking { get; set; }
    }
    public class ServiceProviderPaymentConfiguration : IEntityTypeConfiguration<ServiceProviderPayment>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderPayment> builder)
        {
            builder.HasKey(sp => sp.Id);
            builder.HasOne(sp => sp.ServiceProviderBooking)
                .WithMany(sb => sb.Payments)
                .HasForeignKey(sp => sp.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
