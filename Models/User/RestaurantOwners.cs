using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class RestaurantOwners
    {
        public string UserId { get; set; } //fk & pk

        public AspDotNetUsers AspDotNetUsers { get; set; }
    }

    public class RestaurantOwnersConfiguration : IEntityTypeConfiguration<RestaurantOwners>
    {
        public void Configure(EntityTypeBuilder<RestaurantOwners> builder)
        {
            builder.HasKey(RestaurantOwners => RestaurantOwners.UserId);


        }
    }
}
