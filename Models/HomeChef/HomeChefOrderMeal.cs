using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.HomeChef
{
    public class HomeChefOrderMeal
    {
        public int Id { get; set; }
        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public bool IsDeleted { get; set; }

        public int HomeChefOrdersId { get; set; }//fk
        public int HomeChefMealsId { get; set; }//fk


        //Relations : 
        public virtual HomeChefOrder HomeChefOrder { get; set; }
        public virtual HomeChefMeal HomeChefMeal { get; set; }

    }

    public class HomeChefOrderMealsConfiguration : IEntityTypeConfiguration<HomeChefOrderMeal>
    {
        public void Configure(EntityTypeBuilder<HomeChefOrderMeal> builder)
        {
            builder.HasKey(homechefordermeal => homechefordermeal.Id);
            builder.Property(homechefordermeal => homechefordermeal.SupPrice).HasColumnType("MONEY");





        }
    }
}
