using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class Drivers
    {
        public string UserId { get; set; } //fk & pk 
        public string LicenseNumber { get; set; }

        public bool Availability { get; set; }


        public AspDotNetUsers AspDotNetUsers { get; set; }

    }

    public class DriversConfiguration : IEntityTypeConfiguration<Drivers>
    {
        public void Configure(EntityTypeBuilder<Drivers> builder)
        {
            builder.HasKey(driver => driver.UserId);
            builder.Property(driver => driver.LicenseNumber).IsRequired();
            builder.Property(driver => driver.LicenseNumber).HasDefaultValue(true).IsRequired();


        }
    }
}
