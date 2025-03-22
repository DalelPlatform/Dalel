using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;

namespace Models.Agency
{
    public class PackageBookingReview
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int BookingId { get; set; }
        public virtual PackageBooking PackageBooking { get; set; }
    }
}

public class PackageBookingReviewConfigration : IEntityTypeConfiguration<PackageBookingReview>
{
    public void Configure(EntityTypeBuilder<PackageBookingReview> modelBuilder)
    {

        modelBuilder.HasKey(Review => Review.Id);
        modelBuilder.HasOne(Review => Review.PackageBooking)
        .WithOne(booking => booking.Review)
        .HasForeignKey<PackageBookingReview>(Review => Review.BookingId)
        .OnDelete(DeleteBehavior.NoAction);

    }
}