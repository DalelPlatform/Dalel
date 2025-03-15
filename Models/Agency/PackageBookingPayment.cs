using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Agency.Enums;

namespace Models.Agency
{
    public class PackageBookingPayment
    {
        public int Id { get; set; }
        public float Amount     { get; set; }
         public decimal AmountPaid { get; set; }
         public decimal CommissionDeducted { get; set; }
        public string CodeApplied { get; set; }
        public string PaymentMethod {  get; set; }

        public  DateTime date {  get; set; }

        public VerificationStatus status { get; set; }
        public int BookingId    { get; set; }
        public PackageBooking PackageBooking { get; set; }
    }
}

public class PackageBookingPaymentConfigration : IEntityTypeConfiguration<PackageBookingPayment>
{
    public void Configure(EntityTypeBuilder<PackageBookingPayment> modelBuilder)
    {

        modelBuilder.HasKey(payment => payment.Id);
        modelBuilder.Property(payment => payment.CodeApplied).HasColumnType("NVARCHAR(20)");
        modelBuilder.HasOne(payment => payment.PackageBooking)
        .WithMany(booking => booking.Payment)
        .HasForeignKey(payment => payment.BookingId)
        .OnDelete(DeleteBehavior.NoAction);

    }
}