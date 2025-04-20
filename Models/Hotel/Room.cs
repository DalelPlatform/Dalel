using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Enums;
using System.ComponentModel.DataAnnotations;
using Models.Hotel;

namespace Models.Hotel
{

    public class Room
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Room number must be up to 10 characters long.")]
        public string RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        public string HotelId { get; set; }
        [Required]
        [Range(typeof(decimal), "0.01", "999999.99", ErrorMessage = "Price must be between 0.01 and 999999.99.")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Bed type must be up to 50 characters long.")]
        public string BedType { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "View type must be up to 50 characters long.")]
        public string ViewType { get; set; }

        [Required]
        [RegularExpression("(Available|Under Maintenance|Occupied)", ErrorMessage = "Status must be 'Available', 'Under Maintenance', or 'Occupied'.")]
        public string Status { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public AvaliabilityStatus Availability { get; set; }

        // Navigation property: each room belongs to one RoomType.
        public virtual RoomType RoomType { get; set; }

        public virtual Hotel Hotel { get; set; }

        // Navigation property: a room can have multiple bookings.
        public virtual ICollection<BookingHotelRoom> BookingHotelRooms { get; set; }
    }

    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Table name
            builder.ToTable("Rooms");

            // Primary key
            builder.HasKey(r => r.Id);

            // RoomNumber: required, maximum length 10
            builder.Property(r => r.RoomNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            // RoomTypeId is required.
            builder.Property(r => r.RoomTypeId)
                   .IsRequired();

            // Price: required; specify column type for precision (adjust precision/scale as needed).
            builder.Property(r => r.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // BedType: required, max length 50.
            builder.Property(r => r.BedType)
                   .IsRequired()
                   .HasMaxLength(50);

            // ViewType: required, max length 50.
            builder.Property(r => r.ViewType)
                   .IsRequired()
                   .HasMaxLength(50);

            // Status: required, max length 50.
            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            // IsActive: required.
            builder.Property(r => r.IsActive)
                   .IsRequired();

            // Availability: required; convert the enum to its string representation.
            builder.Property(r => r.Availability)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(50);

            // Configure the relationship between Room and RoomType:
            builder.HasOne(r => r.RoomType)
                   .WithMany(rt => rt.Rooms)
                   .HasForeignKey(r => r.RoomTypeId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Configure the inverse relationship with BookingHotelRoom (if applicable).
            builder.HasMany(r => r.BookingHotelRooms)
                   .WithOne(b => b.Room)
                   .HasForeignKey(b => b.RoomId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
