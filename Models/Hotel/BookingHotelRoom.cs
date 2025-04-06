using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.User;
using Models.Enums;

namespace Models.Hotel
{
    public class BookingHotelRoom
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public float Price { get; set; }
        public int NumberOfGuests { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public string ClientId { get; set; }
        public int RoomId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<BookingGuestInRoom> BookingGuestsInRooms { get; set; }
        public virtual PaymentHotelRoom PaymentHotelRoom { get; set; }
        public virtual ReviewHotelRoom ReviewHotelRoom { get; set; }
        public bool IsAvailable { get; set; }
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
