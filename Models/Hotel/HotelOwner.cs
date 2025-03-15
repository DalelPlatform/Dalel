using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class HotelOwner
    {
        public string UserId { get; set; }

        // Navigation property for one-to-one with AspNetUser
        public AspNetUser User { get; set; }

        // Navigation property for the Hotel (assumed one-to-one)
        public Hotel Hotel { get; set; }
    }


    public class HotelOwnerConfiguration : IEntityTypeConfiguration<HotelOwner>
    {
        public void Configure(EntityTypeBuilder<HotelOwner> builder)
        {
            builder.ToTable("HotelOwners");
            builder.HasKey(h => h.UserId);
            builder.Property(h => h.UserId)
                   .IsRequired()
                   .HasMaxLength(450);

            builder.HasOne(h => h.User)
                   .WithOne(u => u.HotelOwner)
                   .HasForeignKey<HotelOwner>(h => h.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
