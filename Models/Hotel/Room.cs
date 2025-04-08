using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Enums;

namespace Models.Hotel
{

    public class Room
    {
        public int Id { get; set; }
        public AvaliabilityStatus Availability { get; set; }
        public int RoomTypeId { get; set; }

        // Navigation property
        public virtual RoomType RoomType { get; set; }
        // To support the inverse of BookingHotelRoom, add:
        public virtual ICollection<BookingHotelRoom> BookingHotelRooms { get; set; }
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
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
