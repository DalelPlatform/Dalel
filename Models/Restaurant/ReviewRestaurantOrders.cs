using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Driver;
using Models.HomeChef;
using Models.User;

namespace Models.Restaurant
{
    public class ReviewRestaurantOrders
    {
        public int Id { get; set; }

        public string Comments { get; set; }
        public float Rating { get; set; }


        public DateTime ModificationDateTime { get; set; }

        public string ClientId { get; set; } //fk

        public int RestaurantOrderId { get; set; } // fk

        //Relations : 

        public Clients clients {  get; set; }
        
        public RestaurantOrders restaurantOrders { get; set; }


        
    }


    public class ReviewRestaurantOrdersConfiguration : IEntityTypeConfiguration<ReviewRestaurantOrders>
    {
        public void Configure(EntityTypeBuilder<ReviewRestaurantOrders> builder)
        {
            builder.HasKey(reviewrestorder => reviewrestorder.Id);
            builder.Property(reviewrestorder => reviewrestorder.Comments).HasColumnType("NVARCHAR(max)");


        }
    }
}
