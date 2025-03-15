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
    public class RestaurantOrder
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float TotalPrice { get; set; }

        public StatusOfOrder OrderStatus { get; set; }

        public bool IsDeleted { get; set; } 

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; } // fk


        //Relations : 
        public virtual Restaurant Restaurant { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<RestaurantOrderItem> RestaurantOrderItem { get; set; }

        public virtual ICollection<ReviewRestaurantOrder> ReviewRestaurantOrder { get; set; }

        
    }


    public class RestaurantOrderConfiguration : IEntityTypeConfiguration<RestaurantOrder>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrder> builder)
        {
            builder.HasKey(restorder => restorder.Id);
            builder.Property(restorder => restorder.Date).HasDefaultValue("GETDATE()");
            builder.Property(restorder => restorder.OrderStatus).HasDefaultValue("panding");

            //Relation between RestaurantOrders & RestaurantOrderItems  (one to many)
            builder.HasMany(restorderitem => restorderitem.RestaurantOrderItem)
                .WithOne(restorder => restorder.RestaurantOrder)
                .HasForeignKey(restorderitem => restorderitem.RestaurantOrderId);
                


            //Relation between ReviewRestaurantOrder & RestaurantOrders  (one to many)
            builder.HasMany(reviewrestorder => reviewrestorder.ReviewRestaurantOrder)
                .WithOne(restorder => restorder.RestaurantOrder)
                .HasForeignKey(reviewrestorder => reviewrestorder.RestaurantOrderId);
           
        }
    }
}
