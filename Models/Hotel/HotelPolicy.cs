using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Models.Hotel
{
    public class HotelPolicy
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int PolicyId { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
    }

    //Hotel Policy configuration
public class HotelPolicyConfiguration : IEntityTypeConfiguration<HotelPolicy>
    {
        public void Configure(EntityTypeBuilder<HotelPolicy> builder)
        {
            builder.HasKey(hp => hp.Id);

            builder.HasOne(hp => hp.Hotel)
                   .WithMany()
                   .HasForeignKey(hp => hp.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
