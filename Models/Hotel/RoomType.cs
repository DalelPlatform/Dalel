using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class RoomType
    {
        public int Id { get; set; }
        public int Type { get; set; } // e.g., single, double, triple, suite
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBeds { get; set; }
        public float Price { get; set; }
        public int HotelId { get; set; }

        // Navigation properties
        public Hotel Hotel { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<RoomTypeImage> RoomTypeImages { get; set; }
    }

    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomTypes");
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Description).HasMaxLength(250);
            builder.Property(rt => rt.Price).HasColumnType("float");

            builder.HasOne(rt => rt.Hotel)
                   .WithMany(h => h.RoomTypes)
                   .HasForeignKey(rt => rt.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
