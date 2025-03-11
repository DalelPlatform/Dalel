using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.HomeChef
{
    public class HomeChefMealImages
    {
        public int Id { get; set; }
        public string Image {  get; set; }

        public int HomeChefMealsId { get; set; } //fk


        //Relations :

        public virtual HomeChefMeals homeChefMeals { get; set; }

    }


    public class HomeChefMealImagesConfiguration : IEntityTypeConfiguration<HomeChefMealImages>
    {
        public void Configure(EntityTypeBuilder<HomeChefMealImages> builder)
        {
            builder.HasKey(homechefmealimg => homechefmealimg.Id);
            builder.Property(homechefmealimg => homechefmealimg.Image).HasColumnType("NVARCHAR(max)");


        }
    }
}
