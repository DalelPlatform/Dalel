using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

namespace Models.Restaurant
{
    public class RestaurantOrder
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float TotalPrice { get; set; }

        public OrderStatus OrderStatus { get; set; } 

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; } // fk

        public string Address { get; set; } 
        public string? Note { get; set; } //optional

        public string? PhoneNumber { get; set; } //optional

        public string City { get; set; } //optional


        //Relations : 
        public virtual Restaurant Restaurant { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<RestaurantOrderItem> RestaurantOrderItems { get; set; }

        public virtual ReviewRestaurantOrder ReviewRestaurantOrder { get; set; }
        public virtual PaymentRestaurantOrder PaymentRestaurantOrder { get; set; }

        
    }


    public class RestaurantOrderConfiguration : IEntityTypeConfiguration<RestaurantOrder>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrder> builder)
        {
            builder.HasKey(restorder => restorder.Id);
            builder.Property(restorder => restorder.Date).HasDefaultValueSql("GETDATE()");
            builder.Property(restorder => restorder.OrderStatus).HasDefaultValue(OrderStatus.Panding);

            builder.HasOne(p => p.Client)
            .WithMany(p => p.RestaurantOrders)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Restaurant)
            .WithMany(p => p.RestaurantOrders)
            .HasForeignKey(p => p.RestaurantId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
