using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Models.HomeChef
{
    public class ReviewHomeChefOrder
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public int HomeChefOrderId { get; set; } 
        public virtual HomeChefOrder HomeChefOrder { get; set; }

        public string HomeChefId { get; set; } //fk

        public virtual User.HomeChef HomeChef { get; set; }
        

    }

    public class ReviewHomeChefOrderConfiguration : IEntityTypeConfiguration<ReviewHomeChefOrder>
    {
        public void Configure(EntityTypeBuilder<ReviewHomeChefOrder> builder)
        {
            builder.HasKey(reviewhomeorder => reviewhomeorder.Id);
            builder.Property(reviewhomeorder => reviewhomeorder.Comments).HasColumnType("NVARCHAR(max)");

            builder.HasOne(Hchef => Hchef.HomeChef)
                .WithMany(review => review.ReviewHomeChefOrders)
                .HasForeignKey(chef => chef.HomeChefOrderId);
        }
    }


}
