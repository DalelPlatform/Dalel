using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Hotel
{
    public class BookingHotelRoom
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public double Price { get; set; }
        public int NumberOfGuests { get; set; }
        public bool IsConfirmed { get; set; }
        public string ClientId { get; set; }
        public int RoomId { get; set; }

        // Navigation Properties
        public Room Room { get; set; }
    }


    //Booking Hotel Room configuration
 

public class BookingHotelRoomConfiguration : IEntityTypeConfiguration<BookingHotelRoom>
    {
        public void Configure(EntityTypeBuilder<BookingHotelRoom> builder)
        {
            builder.HasKey(bhr => bhr.Id);

            builder.HasOne(bhr => bhr.Room)
                   .WithMany()
                   .HasForeignKey(bhr => bhr.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
