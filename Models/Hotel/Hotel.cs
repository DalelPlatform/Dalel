using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public bool CancelationOptions { get; set; }
        public float CancelationCharges { get; set; }
        public string OwnerId { get; set; }

        // Navigation properties
        public HotelOwner Owner { get; set; }
        public ICollection<HotelPolicy> HotelPolicies { get; set; }
        public ICollection<HotelService> HotelServices { get; set; }
        public ICollection<HotelImage> HotelImages { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
    }


    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotels");
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).IsRequired();

            // One-to-one: HotelOwner -> Hotel
            builder.HasOne(h => h.Owner)
                   .WithOne(o => o.Hotel)
                   .HasForeignKey<Hotel>(h => h.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
