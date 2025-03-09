using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Hotel
{
    public class Room
    {
        public int Id { get; set; }
        public bool Availability { get; set; }
        public int RoomTypeId { get; set; }

        // Navigation Property
        public RoomType RoomType { get; set; }
    }


    //Room Configuration

public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.RoomType)
                   .WithMany()
                   .HasForeignKey(r => r.RoomTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
