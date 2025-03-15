using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class BookingGuestInRoom
    {
        public int Id { get; set; }
        public int RoomDetailsId { get; set; }
        public string FullName { get; set; }
        public string NationalID { get; set; }
        public string NationalIDImage { get; set; }

        // Navigation property
        public BookingHotelRoom BookingHotelRoom { get; set; }
    }

    public class BookingGuestInRoomConfiguration : IEntityTypeConfiguration<BookingGuestInRoom>
    {
        public void Configure(EntityTypeBuilder<BookingGuestInRoom> builder)
        {
            builder.ToTable("BookingGuestsInRooms");
            builder.HasKey(bgir => bgir.Id);

            builder.HasOne(bgir => bgir.BookingHotelRoom)
                   .WithMany(bhr => bhr.BookingGuestsInRooms)
                   .HasForeignKey(bgir => bgir.RoomDetailsId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
