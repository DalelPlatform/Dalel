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
        public AppUser AppUser { get; set; }
        public Restaurant Restaurant { get; set; }
    }

    public class RestaurantOwnersConfiguration : IEntityTypeConfiguration<RestaurantOwner>
    {
        public void Configure(EntityTypeBuilder<RestaurantOwner> builder)
        {
            builder.HasKey(RestaurantOwners => RestaurantOwners.UserId);


        }
    }
}
