using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Hotel
{
    public class RoomType
    {
        public int Id { get; set; }
        public int Type { get; set; } // Single, Double, etc.
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBeds { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }

        // Navigation Property
        public Hotel Hotel { get; set; }
    }


    //Room Type Configuration


public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Description).HasMaxLength(250);

            builder.HasOne(rt => rt.Hotel)
                   .WithMany()
                   .HasForeignKey(rt => rt.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
