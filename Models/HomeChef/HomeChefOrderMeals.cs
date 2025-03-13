using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.HomeChef
{
    public class HomeChefOrderMeals
    {
        public int Id { get; set; }
        public double SupPrice { get; set; }

        public int Quantity { get; set; }

        public int HomeChefOrdersId { get; set; }//fk
        public int HomeChefMealsId { get; set; }//fk


        //Relations : 
        public HomeChefOrders homeChefOrders { get; set; }
        public HomeChefMeals homeChefMeals { get; set; }

    }

    public class HomeChefOrderMealsConfiguration : IEntityTypeConfiguration<HomeChefOrderMeals>
    {
        public void Configure(EntityTypeBuilder<HomeChefOrderMeals> builder)
        {
            builder.HasKey(homechefordermeal => homechefordermeal.Id);
            builder.Property(homechefordermeal => homechefordermeal.SupPrice).HasColumnType("MONEY");





        }
    }
}
