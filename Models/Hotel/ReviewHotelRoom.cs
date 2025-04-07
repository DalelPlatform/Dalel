using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.Hotel
{
    public class ReviewHotelRoom
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public int BookingHotelRoomId { get; set; }

        public virtual BookingHotelRoom BookingHotelRoom { get; set; }
    }

    public class ReviewHotelRoomConfiguration : IEntityTypeConfiguration<ReviewHotelRoom>
    {
        public void Configure(EntityTypeBuilder<ReviewHotelRoom> builder)
        {
            builder.ToTable("ReviewHotelRooms");
            builder.HasKey(rhr => rhr.Id);

            builder.HasOne(rhr => rhr.BookingHotelRoom)
                   .WithOne(bhr => bhr.ReviewHotelRoom)
                   .HasForeignKey< ReviewHotelRoom>(rhr => rhr.BookingHotelRoomId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
