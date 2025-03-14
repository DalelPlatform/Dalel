using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Property;
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
            



            base.OnModelCreating(builder);
        }
    }
}
