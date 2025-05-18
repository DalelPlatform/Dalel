using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;

namespace Models.Restaurant
{
    public class PaymentRestaurantOrder
    {
        public int Id { get; set; }

        public float Amount { get; set; }  

        public decimal AmountPaid { get; set; }

        public decimal? CommissionDeducted { get; set; }

        public string? CodeApplied { get; set; }

        public PaymentMethod PaymentType { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime TransactionDateTime { get; set; }

        public int RestaurantOrderId { get; set; } //fk

        public virtual RestaurantOrder RestaurantOrder { get; set; }
    }


    public class PaymentRestaurantOrderConfiguration : IEntityTypeConfiguration<PaymentRestaurantOrder>
    {
        public void Configure(EntityTypeBuilder<PaymentRestaurantOrder> builder)
        {
            builder.HasKey(payrestorder => payrestorder.Id);
            builder.Property(payrestorder => payrestorder.CodeApplied).IsRequired(false);
            builder.Property(payrestorder => payrestorder.CommissionDeducted).IsRequired(false);
            builder.Property(payrestorder => payrestorder.PaymentType).HasDefaultValue(PaymentMethod.Cash);
            builder.Property(payrestorder => payrestorder.PaymentStatus).HasDefaultValue(PaymentStatus.Pending);

            builder.HasOne(p => p.RestaurantOrder)
            .WithOne(p => p.PaymentRestaurantOrder)
            .HasForeignKey<PaymentRestaurantOrder>(p => p.RestaurantOrderId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
