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
    public class RestaurantOwner
    {
        public string UserId { get; set; } //fk & pk


        //Relations :
        public virtual AppUser AppUser { get; set; }
        public virtual Restaurant.Restaurant Restaurant { get; set; }
    }

    public class RestaurantOwnerConfiguration : IEntityTypeConfiguration<RestaurantOwner>
    {
        public void Configure(EntityTypeBuilder<RestaurantOwner> builder)
        {
            builder.HasKey(RestaurantOwners => RestaurantOwners.UserId);


        }
    }
}
