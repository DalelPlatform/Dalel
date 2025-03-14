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
    public class ReviewRestaurantOrder
    {
        public int Id { get; set; }

        public string Comments { get; set; }
        public float Rating { get; set; }


        public DateTime ModificationDateTime { get; set; }

        public string ClientId { get; set; } //fk

        public int RestaurantOrderId { get; set; } // fk

        //Relations : 

        public virtual Client Client {  get; set; }
        
        public virtual RestaurantOrder RestaurantOrder { get; set; }


        
    }


    public class ReviewRestaurantOrdersConfiguration : IEntityTypeConfiguration<ReviewRestaurantOrder>
    {
        public void Configure(EntityTypeBuilder<ReviewRestaurantOrder> builder)
        {
            builder.HasKey(reviewrestorder => reviewrestorder.Id);
            builder.Property(reviewrestorder => reviewrestorder.Comments).HasColumnType("NVARCHAR(max)");


        }
    }
}
