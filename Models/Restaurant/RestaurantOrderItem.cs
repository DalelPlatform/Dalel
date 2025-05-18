using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class RestaurantOrderItem
    {
        public int Id { get; set; }

        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public int RestaurantOrderId { get; set; } //fk

        public int RestaurantMenuItemId { get; set; } //fk

        public virtual RestaurantOrder RestaurantOrder { get; set; }

        public virtual RestaurantMenuItem RestaurantMenuItem { get; set; }
    }

    public class RestaurantOrderItemConfiguration : IEntityTypeConfiguration<RestaurantOrderItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantOrderItem> builder)
        {
            builder.HasKey(restorderitem => restorderitem.Id);

            builder.HasOne(p => p.RestaurantOrder)
            .WithMany(p => p.RestaurantOrderItems)
            .HasForeignKey(p => p.RestaurantOrderId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.RestaurantMenuItem)
            .WithMany(p => p.RestaurantOrderItems)
            .HasForeignKey(p => p.RestaurantMenuItemId)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
