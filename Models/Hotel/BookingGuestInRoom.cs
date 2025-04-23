using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Hotel;

namespace Models.Hotel
{
    public class BookingGuestInRoom
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string NationalIDImage { get; set; }

        public int BookingHotelRoomId { get; set; }
        // Navigation property
        public virtual BookingHotelRoom BookingHotelRoom { get; set; }
    }

    public class BookingGuestInRoomConfiguration : IEntityTypeConfiguration<BookingGuestInRoom>
    {
        public void Configure(EntityTypeBuilder<BookingGuestInRoom> builder)
        {
            builder.ToTable("BookingGuestsInRooms");
            builder.HasKey(bgir => bgir.Id);

            builder.HasOne(bgir => bgir.BookingHotelRoom)
                   .WithMany(bhr => bhr.BookingGuestsInRooms)
                   .HasForeignKey(bgir => bgir.BookingHotelRoomId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
