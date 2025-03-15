using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{

    public class Room
    {
        public int Id { get; set; }
        public bool Availability { get; set; }
        public int RoomTypeId { get; set; }

        // Navigation property
        public RoomType RoomType { get; set; }
        // To support the inverse of BookingHotelRoom, add:
        public ICollection<BookingHotelRoom> BookingHotelRooms { get; set; }
    }


    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.RoomType)
                   .WithMany(rt => rt.Rooms)
                   .HasForeignKey(r => r.RoomTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
