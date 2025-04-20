using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;

namespace Models.HomeService
{
    public class ServiceProviderPayment
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public DateTime TransactionDateTime { get; set; }
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

            builder.Property(sp => sp.CodeApplied).IsRequired(false);
            builder.Property(sp => sp.CommissionDeducted).IsRequired(false);
            builder.Property(sp => sp.PaymentMethod).HasDefaultValue(PaymentMethod.Cash);
            builder.Property(sp => sp.PaymentStatus).HasDefaultValue(PaymentStatus.Pending);
            builder.Property(sp => sp.Amount).IsRequired();
            builder.Property(sp => sp.AmountPaid).IsRequired();
        }
    }
}
