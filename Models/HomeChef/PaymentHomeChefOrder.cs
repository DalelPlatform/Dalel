using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Enums;

namespace Models.HomeChef
{
    public class PaymentHomeChefOrder
    {
        
         public int Id { get; set; }
         public float Amount { get; set; }
         public decimal AmountPaid { get; set; }

         public decimal? CommissionDeducted { get; set; }

         public string? CodeApplied { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }

         public int HomeChefOrderId { get; set; } 

        public virtual HomeChefOrder HomeChefOrder { get; set; }
     }

    public class PaymentHomeChefOrderConfiguration : IEntityTypeConfiguration<PaymentHomeChefOrder>
    {
        public void Configure(EntityTypeBuilder<PaymentHomeChefOrder> builder)
        {
            builder.HasKey(payhomecheforder => payhomecheforder.Id);
            builder.Property(payhomecheforder => payhomecheforder.CommissionDeducted).IsRequired(false);
            builder.Property(payhomecheforder => payhomecheforder.CodeApplied).HasColumnType("NVARCHAR(50)").IsRequired(false);
            builder.Property(payhomecheforder => payhomecheforder.PaymentMethod).HasDefaultValue(PaymentMethod.Cash);
            builder.Property(payhomecheforder => payhomecheforder.PaymentStatus).HasDefaultValue(PaymentStatus.Pending);
        }
    }
}
