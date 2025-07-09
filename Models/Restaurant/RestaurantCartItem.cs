using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Restaurant
{
    public class RestaurantCartItem
    {
        public int Id { get; set; }

        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public virtual Client Client { get; set; }
        public string ClientId { get; set; } // fk

        public int RestaurantMenuItemId { get; set; } 

        public virtual RestaurantMenuItem RestaurantMenuItem { get; set; }

        public bool IsDeleted { get; set; } = false; // default value is false, not deleted
    }

    public class RestaurautCartItemConfiguration : IEntityTypeConfiguration<RestaurantCartItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantCartItem> builder)
        {
            builder.HasKey(restorderitem => restorderitem.Id);

            builder.HasOne(p => p.Client)
            .WithMany(p => p.RestaurautCartItems)
            .HasForeignKey(p => p.RestaurantMenuItemId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.RestaurantMenuItem)
            .WithMany(p => p.RestaurautCartItems)
            .HasForeignKey(p => p.RestaurantMenuItemId)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}

  