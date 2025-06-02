using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Models.User
{
    public class AppUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalId { get; set; }
        public string? Location { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? ProfileImg { get; set; }

        public string? ModificationBy { get; set; }

        public DateTime? ModificationDate { get; set; }

        public bool? IsDeleted { get; set; }


        //Relations :
        public virtual Client? Client { get; set; }
        public virtual Drivers? Driver { get; set; }
        public virtual HotelOwners? HotelOwner { get; set; }
        public virtual RestaurantOwner? RestaurantOwner { get; set; }
        public virtual PropertyOwner? PropertyOwner { get; set; }
        public virtual HomeChef? HomeChef { get; set; }
        public virtual TravelAgencyOwners? TravelAgencyOwner { get; set; }
        public virtual ServiceProvider? ServiceProvider { get; set; }    
    }

    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(asp => asp.NationalId).HasColumnType("NVARCHAR(14)").IsRequired();
            builder.HasIndex(asp => asp.NationalId).IsUnique();
            builder.Property(p => p.ModificationDate).HasDefaultValueSql("GetDate()");

            builder.Property(asp => asp.Location).HasColumnType("NVARCHAR(500)").HasDefaultValue("empty");
            builder.Property(asp => asp.Address).HasColumnType("NVARCHAR(500)").HasDefaultValue("empty");
            builder.Property(asp => asp.City).HasColumnType("NVARCHAR(500)").HasDefaultValue("empty");
            builder.Property(asp => asp.ProfileImg).HasColumnType("NVARCHAR(500)").HasDefaultValue("empty");
        }
    }
}
