using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class ReviewRestaurantOrder
    {
        public int Id { get; set; }

        public string Comments { get; set; }
        public float Rating { get; set; }

        public DateTime ModificationDateTime { get; set; }

        public int RestaurantOrderId { get; set; } // fk
                
        public virtual RestaurantOrder RestaurantOrder { get; set; }
        
    }


    public class ReviewRestaurantOrderConfiguration : IEntityTypeConfiguration<ReviewRestaurantOrder>
    {
        public void Configure(EntityTypeBuilder<ReviewRestaurantOrder> builder)
        {
            builder.HasKey(reviewrestorder => reviewrestorder.Id);
            builder.Property(reviewrestorder => reviewrestorder.Comments).HasColumnType("NVARCHAR(max)");

            builder.HasOne(p => p.RestaurantOrder)
                .WithOne(p => p.ReviewRestaurantOrder)
                .HasForeignKey<ReviewRestaurantOrder>(p => p.RestaurantOrderId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
