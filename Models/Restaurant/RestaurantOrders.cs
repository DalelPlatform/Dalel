using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Driver;
using Models.Restaurant.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class RestaurantOrders
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float TotalPrice { get; set; }

        public StatusOfOrder OrderStatus { get; set; }

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; } // fk


        //Relations : 
        public Restaurants restaurants { get; set; }
        public Clients clients { get; set; }

        public ICollection<RestaurantOrderItems> restaurantOrderItems { get; set; }

        public ICollection<ReviewRestaurantOrders> reviewRestaurantOrders { get; set; }

        
    }


    public class RestaurantOrdersConfiguration : IEntityTypeConfiguration<RestaurantOrders>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrders> builder)
        {
            builder.HasKey(restorder => restorder.Id);
            builder.Property(restorder => restorder.Date).HasDefaultValue("GETDATE()");
            builder.Property(restorder => restorder.OrderStatus).HasDefaultValue("panding");

            //Relation between RestaurantOrders & RestaurantOrderItems  (one to many)
            builder.HasMany(restorderitem => restorderitem.restaurantOrderItems)
                .WithOne(restorder => restorder.restaurantOrders)
                .HasForeignKey(restorderitem => restorderitem.RestaurantOrderId);



            builder.HasMany(reviewrestorder => reviewrestorder.reviewRestaurantOrders)
                .WithOne(restorder => restorder.restaurantOrders)
                .HasForeignKey(reviewrestorder => reviewrestorder.RestaurantOrderId);
           
        }
    }
}
