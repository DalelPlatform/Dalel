using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeChef.Enums;
using Models.User;

namespace Models.HomeChef
{
    public class HomeChefOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }

        public StatusOfOrder OrderStatus { get; set; }

        public int HomeChefId { get; set; } //fk
        public string ClientId { get; set; } //fk

        //Relations : 

        public virtual User.HomeChef HomeChef { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<HomeChefOrderMeal>  HomeChefOrderMeal { get; set; }

        public virtual ICollection<PaymentHomeChefOrder> PaymentHomeChefOrder { get; set; }

        public virtual ICollection<ReviewHomeChefOrder> ReviewHomeChefOrder { get; set; }


    }

    public class HomeChefOrdersConfiguration : IEntityTypeConfiguration<HomeChefOrder>
    {
        public void Configure(EntityTypeBuilder<HomeChefOrder> builder)
        {
            builder.HasKey(homecheforder => homecheforder.Id);
            builder.Property(homecheforder => homecheforder.OrderDate).HasDefaultValue("GETDATE()");
            builder.Property(homecheforder => homecheforder.OrderStatus).HasDefaultValue("panding");


            //relation between HomeChefOrders & HomeChefOrderMeals (one to many)
            builder.HasMany(homechefordermeal => homechefordermeal.HomeChefOrderMeal)
                .WithOne(homecheforder => homecheforder.HomeChefOrder)
                .HasForeignKey(homecheforder => homecheforder.HomeChefOrdersId);


            //relation between HomeChefOrders & PaymentHomeChefOrders (one to many)
            builder.HasMany(payhomecheforder => payhomecheforder.PaymentHomeChefOrder)
                .WithOne(homecheforder => homecheforder.HomeChefOrder)
                .HasForeignKey(homecheforder => homecheforder.HomeChefOrderId)
                .OnDelete(DeleteBehavior.NoAction);



            //relation between HomeChefOrders & ReviewHomeChefOrders (one to many)
            builder.HasMany(reviewhomecheforder => reviewhomecheforder.ReviewHomeChefOrder)
                .WithOne(homecheforder => homecheforder.HomeChefOrder)
                .HasForeignKey(reviewhomecheforder => reviewhomecheforder.HomeChefOrderId);


        }
    }
}
