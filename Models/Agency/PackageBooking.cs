using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Agency.Enums;
using Models.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Models.User;

namespace Models.Agency
{


    public class PackageBooking
    {
        public int Id { get; set; }
        public VerificationStatus PaymentStatus { get; set; }
        public DateTime Date { get; set; }
        public int ReservedPeople { get; set; }
        public float TotalPrice { get; set; }
        public int PackageSchaduleId { get; set; }
        public PackageSchadule PackageSchadule { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
        public ICollection<PackageBookingPayment> Payment { get; set; }
        public ICollection <PackageBookingReview > Review { get; set; }
    }
}

public class PackageBookingConfigration : IEntityTypeConfiguration<PackageBooking>
{
    public void Configure(EntityTypeBuilder<PackageBooking> modelBuilder)
    {
        modelBuilder.HasKey(PackageBooking => PackageBooking.Id);
        modelBuilder.HasOne(c =>c.Client)
        .WithMany(packg => packg.PackageBookings)
        .HasForeignKey(PackageBooking => PackageBooking.ClientId);

        modelBuilder.HasOne(PackageBooking => PackageBooking.PackageSchadule)
        .WithMany(Schadule => Schadule.PabckageBookings)
        .HasForeignKey(PackageBooking => PackageBooking.PackageSchaduleId);

    }
}
