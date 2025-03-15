using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class RoomTypeImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int RoomTypeId { get; set; }

        // Navigation property
        public RoomType RoomType { get; set; }
    }


    public class RoomTypeImageConfiguration : IEntityTypeConfiguration<RoomTypeImage>
    {
        public void Configure(EntityTypeBuilder<RoomTypeImage> builder)
        {
            builder.ToTable("RoomTypeImages");
            builder.HasKey(rti => rti.Id);

            builder.HasOne(rti => rti.RoomType)
                   .WithMany(rt => rt.RoomTypeImages)
                   .HasForeignKey(rti => rti.RoomTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
