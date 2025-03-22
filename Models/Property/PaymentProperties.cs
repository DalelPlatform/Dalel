using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;

namespace Models.Property
{
    public class PaymentProperties
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public int BookingPropertyId { get; set; } // fk BookingProperties.Id
        //relations
        public virtual BookingProperties BookingProperties { get; set; }
    }

    public class PaymentPropertiesConfiguration : IEntityTypeConfiguration<PaymentProperties>
    {
        public void Configure(EntityTypeBuilder<PaymentProperties> builder)
        {
            builder.HasKey(pp => pp.Id);
            builder.Property(pp => pp.Amount).HasColumnType("decimal(18,2)");
            builder.Property(pp => pp.CodeApplied).IsRequired(false);
            builder.Property(pp => pp.CommissionDeducted).IsRequired(false);
            

            builder.HasOne(pp => pp.BookingProperties)
                .WithOne(bp => bp.PaymentProperties)
                .HasForeignKey<PaymentProperties>(pp => pp.BookingPropertyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
