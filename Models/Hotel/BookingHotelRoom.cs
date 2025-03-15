using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class BookingHotelRoom
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public float Price { get; set; }
        public int NumberOfGuests { get; set; }
        public bool isConfirmed { get; set; }
        public string ClientId { get; set; }
        public int RoomId { get; set; }

        // Navigation properties
        public AspNetUser Client { get; set; }
        public Room Room { get; set; }
        public ICollection<BookingGuestInRoom> BookingGuestsInRooms { get; set; }
        public ICollection<PaymentHotelRoom> PaymentHotelRooms { get; set; }
        public ICollection<ReviewHotelRoom> ReviewHotelRooms { get; set; }
    }

    public class BookingHotelRoomConfiguration : IEntityTypeConfiguration<BookingHotelRoom>
    {
        public void Configure(EntityTypeBuilder<BookingHotelRoom> builder)
        {
            builder.ToTable("BookingHotelRooms");
            builder.HasKey(bhr => bhr.Id);

            builder.HasOne(bhr => bhr.Client)
                   .WithMany(u => u.BookingHotelRooms)
                   .HasForeignKey(bhr => bhr.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bhr => bhr.Room)
                   .WithMany(r => r.BookingHotelRooms)
                   .HasForeignKey(bhr => bhr.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
