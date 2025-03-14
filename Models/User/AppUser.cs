using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Models.HomeService;

namespace Models.User
{
    public class AppUser : IdentityUser
    {

        public string NationalId { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ProfileImg { get; set; }

        public string ModificationBy { get; set; }

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted { get; set; }


        //Relations :
        public virtual Client? Client { get; set; }
        public Drivers? drivers { get; set; }
        public HotelOwners? hotelOwners { get; set; }
        public PropertyOwner? propertyOwner { get; set; }
        public RestaurantOwners? restaurantOwners { get; set; }
        public HomeChefs? homeChefs { get; set; }
        public Agency? agency { get; set; }
        public ServiceProvider? ServiceProvider { get; set; }    

    }

    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(asp => asp.NationalId).HasColumnType("NVARCHAR(14)").IsRequired();
            builder.HasIndex(asp => asp.NationalId);
            builder.Property(asp => asp.Location).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.Address).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.City).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.ProfileImg).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.ModificationBy).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.Address).HasDefaultValue(false);
            
           
            builder.HasOne(client => client.Client)
                .WithOne(usr => usr.User)
                .HasForeignKey<Client>(client => client.UserId);

          
            builder.HasOne(drivers => drivers.drivers)
                .WithOne(usr => usr.AppUser)
                .HasForeignKey<Drivers>(drivers => drivers.UserId);

            builder.HasOne(hotelowners => hotelowners.hotelOwners)
                 .WithOne(usr => usr.AspDotNetUsers)
                 .HasForeignKey<HotelOwners>(hotelowners => hotelowners.UserId);

            builder.HasOne(proOwner => proOwner.propertyOwner)
                .WithOne(usr => usr.AppUser)
                .HasForeignKey<PropertyOwner>(proOwner => proOwner.UserId);

            builder.HasOne(restaurantOwners => restaurantOwners.restaurantOwners)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey<RestaurantOwners>(restaurantOwners => restaurantOwners.UserId);

            builder.HasOne(homeChefs => homeChefs.homeChefs)
               .WithOne(usr => usr.AppUser)
               .HasForeignKey<HomeChefs>(homeChefs => homeChefs.UserId);

            builder.HasOne(agency => agency.agency)
               .WithOne(usr => usr.AspDotNetUsers)
               .HasForeignKey<Agency>(agency => agency.UserId);

        }
    }
}
