using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class HotelOwners
    {
        public string UserId { get; set; } // fk & pk

        public AspDotNetUsers AspDotNetUsers { get; set; }
    }

    public class HotelOwnersConfiguration : IEntityTypeConfiguration<HotelOwners>
    {
        public void Configure(EntityTypeBuilder<HotelOwners> builder)
        {
            builder.HasKey(hotelowners => hotelowners.UserId);


        }
    }
}
