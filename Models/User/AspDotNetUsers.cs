using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Models.HomeService;
using Models.Driver;

namespace Models.User
{
    public class AspDotNetUsers
    {
        public string Id { get; set; }

        public string NationalId { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ProfileImg { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string ModificationBy { get; set; }

        public DateTime ModificationDate { get; set; }

        public bool IsDeleted { get; set; }


        //Relations :
        public ICollection<AspDotNetUserRoles> AspDotNetUserRoles { get; set; }
        public Clients clients { get; set; }
        public Cookers cookers { get; set; }
        public Drivers drivers { get; set; }
        public HotelOwners hotelOwners { get; set; }
        public PropertyOwners propertyOwners { get; set; }
        public RestaurantOwners restaurantOwners { get; set; }
        public HomeChefs homeChefs { get; set; }
        public Agency agency { get; set; }
        public HomeService.ServiceProvider ServiceProvider { get; set; }

       
      

    }

    public class AspDotNetUsersConfiguration : IEntityTypeConfiguration<AspDotNetUsers>
    {
        public void Configure(EntityTypeBuilder<AspDotNetUsers> builder)
        {
            builder.HasKey(asp => asp.Id);
            builder.Property(asp => asp.NationalId).HasColumnType("NVARCHAR(14)").IsRequired();
            builder.HasIndex(asp => asp.NationalId);
            builder.Property(asp => asp.Location).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.Address).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.City).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.ProfileImg).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.UserName).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(asp => asp.PasswordHash).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.Email).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(asp => asp.PhoneNumber).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.ModificationBy).HasColumnType("NVARCHAR(50)").HasDefaultValue("empty");
            builder.Property(asp => asp.Address).HasDefaultValue(false);
            
            builder.HasMany(usrRoles => usrRoles.AspDotNetUserRoles)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey(usrRoles => usrRoles.UserId);

            builder.HasOne(client => client.clients)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey<Clients>(client => client.UserId);

            builder.HasOne(cookers => cookers.cookers)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey<Cookers>(cookers => cookers.UserId);

            builder.HasOne(drivers => drivers.drivers)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey<Drivers>(drivers => drivers.UserId);

            builder.HasOne(hotelowners => hotelowners.hotelOwners)
                 .WithOne(usr => usr.AspDotNetUsers)
                 .HasForeignKey<HotelOwners>(hotelowners => hotelowners.UserId);

            builder.HasOne(proOwner => proOwner.propertyOwners)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey<PropertyOwners>(proOwner => proOwner.UserId);

            builder.HasOne(restaurantOwners => restaurantOwners.restaurantOwners)
                .WithOne(usr => usr.AspDotNetUsers)
                .HasForeignKey<RestaurantOwners>(restaurantOwners => restaurantOwners.UserId);

            builder.HasOne(homeChefs => homeChefs.homeChefs)
               .WithOne(usr => usr.AspDotNetUsers)
               .HasForeignKey<HomeChefs>(homeChefs => homeChefs.UserId);

            builder.HasOne(agency => agency.agency)
               .WithOne(usr => usr.AspDotNetUsers)
               .HasForeignKey<Agency>(agency => agency.UserId);

        }
    }
}
