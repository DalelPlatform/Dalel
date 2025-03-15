using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.HomeChef;
using Models.Property;
using Models.Restaurant;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DelelContext : IdentityDbContext<AppUser>
    {
        //not add DbSet AppUser

        public  DbSet<Client> Client { get; set; }
        public DbSet<PropertyOwner> PropertyOwner { get; set; }

        public DbSet<RestaurantOwner> RestaurantOwner { get; set; }

        public DbSet<User.HomeChef> HomeChef { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // add string connection
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User & Client Configuration
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());

            #region Property
            builder.ApplyConfiguration(new PropertyOwnerConfiguration());
            builder.ApplyConfiguration(new PropertiesConfigiruation());
            builder.ApplyConfiguration(new BookingPropertiesConfiguration());
            builder.ApplyConfiguration(new PaymentPropertiesConfiguration());
            builder.ApplyConfiguration(new PropertyImagesConfiguration());
            builder.ApplyConfiguration(new ReviewPropertiesConfiguration());
            #endregion

            #region Restaurant 
            builder.ApplyConfiguration(new RestaurantOwnerConfiguration());
            builder.ApplyConfiguration(new PaymentRestaurantOrderConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new RestaurantImageConfiguration());
            builder.ApplyConfiguration(new RestaurantMenuItemImageConfiguration());
            builder.ApplyConfiguration(new RestaurantMenuItemConfiguration());
            builder.ApplyConfiguration(new RestaurantOrderConfiguration());
            builder.ApplyConfiguration(new RestaurantOrderItemConfiguration());
            builder.ApplyConfiguration(new RestaurantReervationConfiguration());
            builder.ApplyConfiguration(new ReviewRestaurantOrderConfiguration());

            #endregion

            #region HomeChef
            builder.ApplyConfiguration(new HomeChefConfiguration());
            builder.ApplyConfiguration(new HomeChefDeliveriesConfiguration());
            builder.ApplyConfiguration(new HomeChefMealConfiguration());
            builder.ApplyConfiguration(new HomeChefMealImageConfiguration());
            builder.ApplyConfiguration(new HomeChefOrderConfiguration());
            builder.ApplyConfiguration(new HomeChefOrderMealConfiguration());
            builder.ApplyConfiguration(new PaymentHomeChefOrderConfiguration());
            builder.ApplyConfiguration(new ReviewHomeChefOrderConfiguration());
            
            #endregion





            base.OnModelCreating(builder);
        }
    }
}
