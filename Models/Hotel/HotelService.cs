using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Models.Hotel
{
    public class HotelService
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int HotelId { get; set; }
        public int ServicesId { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
        public Service Service { get; set; }
    }

    //hotel Services Configuration
    public class HotelServiceConfiguration : IEntityTypeConfiguration<HotelService>
    {
        public void Configure(EntityTypeBuilder<HotelService> builder)
        {
            builder.HasKey(hs => hs.Id);

            builder.Property(hs => hs.Price).HasDefaultValue(0);

            builder.HasOne(hs => hs.Hotel)
                   .WithMany(h => h.HotelServices)
                   .HasForeignKey(hs => hs.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(hs => hs.Service)
                   .WithMany()
                   .HasForeignKey(hs => hs.ServicesId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
