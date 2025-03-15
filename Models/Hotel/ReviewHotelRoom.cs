using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class ReviewHotelRoom
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string ClientId { get; set; }
        public int BookingHotelRoomId { get; set; }

        // Navigation properties
        public AspNetUser Client { get; set; }
        public BookingHotelRoom BookingHotelRoom { get; set; }
    }

    public class ReviewHotelRoomConfiguration : IEntityTypeConfiguration<ReviewHotelRoom>
    {
        public void Configure(EntityTypeBuilder<ReviewHotelRoom> builder)
        {
            builder.ToTable("ReviewHotelRooms");
            builder.HasKey(rhr => rhr.Id);

            builder.HasOne(rhr => rhr.Client)
                   .WithMany(u => u.ReviewHotelRooms)
                   .HasForeignKey(rhr => rhr.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rhr => rhr.BookingHotelRoom)
                   .WithMany(bhr => bhr.ReviewHotelRooms)
                   .HasForeignKey(rhr => rhr.BookingHotelRoomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
