using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;

namespace Models.Hotel
{
    public class HotelOwner
    {
        public string UserId { get; set; }

        // Navigation Properties
        public HotelOwners User { get; set; }
    }




public class HotelOwnerConfiguration : IEntityTypeConfiguration<HotelOwner>
    {
        public void Configure(EntityTypeBuilder<HotelOwner> builder)
        {
            builder.HasKey(ho => ho.UserId);

            builder.HasOne(ho => ho.User)
                   .WithOne()
                   .HasForeignKey<HotelOwner>(ho => ho.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
