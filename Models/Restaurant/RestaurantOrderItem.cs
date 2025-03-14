using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class RestaurantOrderItem
    {
        public int Id { get; set; }

        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public bool IsDeleted {  get; set; }

        public int RestaurantOrderId { get; set; } //fk

        public int RestaurantMenuItemId { get; set; } //fk

        //Relations :

        public virtual RestaurantOrder RestaurantOrder { get; set; }

        public virtual RestaurantMenuItem RestaurantMenuItem { get; set; }
        

    }

    public class RestaurantOrderItemsConfiguration : IEntityTypeConfiguration<RestaurantOrderItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderItem> builder)
        {
            builder.HasKey(restorderitem => restorderitem.Id);



        }
    }
}
