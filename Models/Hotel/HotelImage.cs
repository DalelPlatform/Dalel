using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Models.Hotel
{
    public class HotelImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int HotelId { get; set; }

        // Navigation Property
        public Hotel Hotel { get; set; }
    }


    //Hotel Image configuration
    public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
    {
        public void Configure(EntityTypeBuilder<HotelImage> builder)
        {
            builder.HasKey(hi => hi.Id);

            builder.HasOne(hi => hi.Hotel)
                   .WithMany(h => h.HotelImages)
                   .HasForeignKey(hi => hi.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
