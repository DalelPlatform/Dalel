using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Enums;


namespace Models.Driver
{
    public class PaymentVehicle
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int BookingVehicleId { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }
    public class PaymentVehicleConfiguration : IEntityTypeConfiguration<PaymentVehicle>
    {
        public void Configure(EntityTypeBuilder<PaymentVehicle> builder)
        {
            // تحديد المفتاح الأساسي
            builder.HasKey(pv => pv.Id);

            // ضبط خصائص الحقول
            builder.Property(pv => pv.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(pv => pv.TransactionDateTime).HasDefaultValueSql("GetDate()");

            // ضبط العلاقة One-to-One مع BookingVehicle
            builder.HasOne(pv => pv.BookingVehicle)
                   .WithOne(bv => bv.Payment) // BookingVehicle لديه فقط Payment واحد
                   .HasForeignKey<PaymentVehicle>(pv => pv.BookingVehicleId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
