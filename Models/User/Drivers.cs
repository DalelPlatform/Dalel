using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Driver;

namespace Models.User
{
    public class Drivers
    {
        public string UserId { get; set; } //fk & pk 
        public string LicenseNumber { get; set; }

        public bool Availability { get; set; }


        public virtual AppUser AppUser { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection <CarProposal> Proposals { get; set; }

    }

    public class DriversConfiguration : IEntityTypeConfiguration<Drivers>
    {
        public void Configure(EntityTypeBuilder<Drivers> builder)
        {
            builder.HasKey(driver => driver.UserId);
            builder.Property(driver => driver.LicenseNumber).IsRequired();
            builder.Property(driver => driver.LicenseNumber).HasDefaultValue(true).IsRequired();

            builder
                .HasOne(a => a.AppUser)
                .WithOne(a => a.Driver)
                .HasForeignKey<Drivers>(a => a.UserId);
        }
    }
}
