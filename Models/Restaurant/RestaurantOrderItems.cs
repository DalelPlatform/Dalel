using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class RestaurantOrderItems
    {
        public int Id { get; set; }

        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public int RestaurantOrderId { get; set; } //fk

        public int RestaurantMenuItemId { get; set; } //fk

        //Relations :

        public RestaurantOrders restaurantOrders { get; set; }

        public RestaurantMenuItems restaurantMenuItems { get; set; }
        

    }

    public class RestaurantOrderItemsConfiguration : IEntityTypeConfiguration<RestaurantOrderItems>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderItems> builder)
        {
            builder.HasKey(restorderitem => restorderitem.Id);



        }
    }
}
