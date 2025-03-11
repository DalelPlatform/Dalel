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
    public class HomeChefOrders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }

        public StatusOfOrder OrderStatus { get; set; }

        public int HomeChefId { get; set; } //fk
        public string ClientId { get; set; } //fk

        //Relations : 

        public HomeChefs homeChefs { get; set; }
        public Clients clients { get; set; }

        public ICollection<HomeChefOrderMeals>  homeChefOrderMeals { get; set; }

        public ICollection<PaymentHomeChefOrders> paymentHomeChefOrders { get; set; }

        public ICollection<ReviewHomeChefOrders> reviewHomeChefOrders { get; set; }


    }

    public class HomeChefOrdersConfiguration : IEntityTypeConfiguration<HomeChefOrders>
    {
        public void Configure(EntityTypeBuilder<HomeChefOrders> builder)
        {
            builder.HasKey(homecheforder => homecheforder.Id);
            builder.Property(homecheforder => homecheforder.OrderDate).HasDefaultValue("GETDATE()");
            builder.Property(homecheforder => homecheforder.OrderStatus).HasDefaultValue("panding");


            //relation between HomeChefOrders & HomeChefOrderMeals (one to many)
            builder.HasMany(homechefordermeal => homechefordermeal.homeChefOrderMeals)
                .WithOne(homecheforder => homecheforder.homeChefOrders)
                .HasForeignKey(homecheforder => homecheforder.HomeChefOrdersId);


            //relation between HomeChefOrders & PaymentHomeChefOrders (one to many)
            builder.HasMany(payhomecheforder => payhomecheforder.paymentHomeChefOrders)
                .WithOne(homecheforder => homecheforder.homeChefOrders)
                .HasForeignKey(homecheforder => homecheforder.HomeChefOrderId);



            //relation between HomeChefOrders & ReviewHomeChefOrders (one to many)
            builder.HasMany(reviewhomecheforder => reviewhomecheforder.reviewHomeChefOrders)
                .WithOne(homecheforder => homecheforder.homeChefOrders)
                .HasForeignKey(reviewhomecheforder => reviewhomecheforder.HomeChefOrderId);


        }
    }
}
