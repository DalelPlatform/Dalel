using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.User;
using Models.Enums;

namespace Models.HomeChef
{
    public class HomeChefOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string HomeChefId { get; set; } //fk
        public string ClientId { get; set; } //fk

        //Relations : 

        public virtual User.HomeChef HomeChef { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<HomeChefOrderMeal>  HomeChefOrderMeals { get; set; }

        public virtual PaymentHomeChefOrder PaymentHomeChefOrder { get; set; }

        public virtual ReviewHomeChefOrder ReviewHomeChefOrder { get; set; }
        public virtual HomeChefDelivery HomeChefDelivery { get; set; }

    }

    public class HomeChefOrderConfiguration : IEntityTypeConfiguration<HomeChefOrder>
    {
        public void Configure(EntityTypeBuilder<HomeChefOrder> builder)
        {
            builder.HasKey(homecheforder => homecheforder.Id);
            builder.Property(homecheforder => homecheforder.OrderDate).HasDefaultValueSql("GETDATE()");
            builder.Property(homecheforder => homecheforder.OrderStatus).HasDefaultValue(OrderStatus.Panding);


            builder.HasOne(HomeChefOrder => HomeChefOrder.Client)
                .WithMany(client => client.HomeChefOrders)
                .HasForeignKey(homecheforder => homecheforder.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(payhomecheforder => payhomecheforder.PaymentHomeChefOrder)
                .WithOne(homecheforder => homecheforder.HomeChefOrder)
                .HasForeignKey<PaymentHomeChefOrder>(homecheforder => homecheforder.HomeChefOrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(reviewhomecheforder => reviewhomecheforder.ReviewHomeChefOrder)
                .WithOne(homecheforder => homecheforder.HomeChefOrder)
                .HasForeignKey<ReviewHomeChefOrder>(reviewhomecheforder => reviewhomecheforder.HomeChefOrderId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
