using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Restaurant;

namespace Models.User
{
    public class RestaurantOwners
    {
        public string UserId { get; set; } //fk & pk


        //Relations :
        public AspDotNetUsers AspDotNetUsers { get; set; }
        public Restaurants restaurants { get; set; }
    }

    public class RestaurantOwnersConfiguration : IEntityTypeConfiguration<RestaurantOwners>
    {
        public void Configure(EntityTypeBuilder<RestaurantOwners> builder)
        {
            builder.HasKey(RestaurantOwners => RestaurantOwners.UserId);


        }
    }
}
