using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.HomeChef
{
    public class HomeChefMealImage
    {
        public int Id { get; set; }
        public string Image {  get; set; }

        public int HomeChefMealsId { get; set; } //fk


        //Relations :

        public virtual HomeChefMeal HomeChefMeal { get; set; }

    }


    public class HomeChefMealImagesConfiguration : IEntityTypeConfiguration<HomeChefMealImage>
    {
        public void Configure(EntityTypeBuilder<HomeChefMealImage> builder)
        {
            builder.HasKey(homechefmealimg => homechefmealimg.Id);
            builder.Property(homechefmealimg => homechefmealimg.Image).HasColumnType("NVARCHAR(max)");


        }
    }
}
