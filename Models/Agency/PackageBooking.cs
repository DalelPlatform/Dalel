using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.User;
using Models.Enums;

namespace Models.Agency
{
    public class PackageBooking
    {
        public int Id { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime Date { get; set; }
        public int ReservedPeople { get; set; }
        public float TotalPrice { get; set; }
        public int PackageSchaduleId { get; set; }
        public string ClientId { get; set; }
        public virtual PackageSchadule PackageSchadule { get; set; }
        public virtual Client Client { get; set; }
        public virtual PackageBookingPayment Payment { get; set; }
        public virtual PackageBookingReview Review { get; set; }
    }


    public class PackageBookingConfigration : IEntityTypeConfiguration<PackageBooking>
    {
        public void Configure(EntityTypeBuilder<PackageBooking> modelBuilder)
        {
            modelBuilder.HasKey(PackageBooking => PackageBooking.Id);
            modelBuilder.HasOne(c => c.Client)
            .WithMany(packg => packg.PackageBookings)
            .HasForeignKey(PackageBooking => PackageBooking.ClientId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.HasOne(PackageBooking => PackageBooking.PackageSchadule)
            .WithMany(Schadule => Schadule.PabckageBookings)
            .HasForeignKey(PackageBooking => PackageBooking.PackageSchaduleId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}