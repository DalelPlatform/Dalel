using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Hotel
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public bool CancelationOptions { get; set; }
        public double CancelationCharges { get; set; }
        public string OwnerId { get; set; }

        // Navigation Properties
        public HotelOwner Owner { get; set; }
        public ICollection<HotelService> HotelServices { get; set; }
        public ICollection<HotelImage> HotelImages { get; set; }
    }


    //Hotel configurations

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).IsRequired().HasMaxLength(255);
            builder.Property(h => h.Description).HasMaxLength(1000);
            builder.Property(h => h.City).HasMaxLength(255);
            builder.Property(h => h.PhoneNumber).HasMaxLength(50);

            builder.HasOne(h => h.Owner)
                   .WithOne()
                   .HasForeignKey<Hotel>(h => h.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
