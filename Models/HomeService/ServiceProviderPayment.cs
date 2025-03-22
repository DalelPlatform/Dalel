using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;

namespace Models.HomeService
{
    public class ServiceProviderPayment
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int RequestId { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
    public class ServiceProviderPaymentConfiguration : IEntityTypeConfiguration<ServiceProviderPayment>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderPayment> builder)
        {
            builder.HasKey(sp => sp.Id);
            builder.HasOne(sp => sp.ServiceRequest)
                .WithOne(sb => sb.Payment)
                .HasForeignKey<ServiceProviderPayment>(sp => sp.RequestId )
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
