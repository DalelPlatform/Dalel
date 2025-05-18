using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Enums;

namespace Models.Agency
{
    public class PackageBookingPayment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal? CommissionDeducted { get; set; }
        public string? CodeApplied { get; set; }
        public PaymentMethod PaymentMethod {  get; set; }
        public PaymentStatus PaymentStatus {  get; set; }
        public DateTime Date {  get; set; }
        public int BookingId    { get; set; }
        public virtual PackageBooking PackageBooking { get; set; }
    }
}

public class PackageBookingPaymentConfigration : IEntityTypeConfiguration<PackageBookingPayment>
{
    public void Configure(EntityTypeBuilder<PackageBookingPayment> modelBuilder)
    {

        modelBuilder.HasKey(payment => payment.Id);
        modelBuilder.Property(payment => payment.CodeApplied).HasColumnType("NVARCHAR(20)");
        modelBuilder.HasOne(payment => payment.PackageBooking)
        .WithOne(booking => booking.Payment)
        .HasForeignKey<PackageBookingPayment>(payment => payment.BookingId)
        .OnDelete(DeleteBehavior.NoAction);

    }
}