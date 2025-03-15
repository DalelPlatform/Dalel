using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public PackageBooking PackageBooking { get; set; }
    }
}

public class PackageBookingReviewConfigration : IEntityTypeConfiguration<PackageBookingReview>
{
    public void Configure(EntityTypeBuilder<PackageBookingReview> modelBuilder)
    {

        modelBuilder.HasKey(Review => Review.Id);
        modelBuilder.HasOne(Review => Review.PackageBooking)
        .WithMany(booking => booking.Review)
        .HasForeignKey(Review => Review.BookingId);

    }
}