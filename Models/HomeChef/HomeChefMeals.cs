using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.HomeChef.Enums;
using Models.User;

namespace Models.HomeChef
{
    public class HomeChefMeals
    {
        public int Id { get; set; }
        public int HomeChefId { get; set; } //fk

        public string DishName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string AvailabilityStatus { get; set; }
        public string DietaryTags { get; set; }

        public CategoryOfFood FoodCategory { get; set; }

        public SizeOfPiece PieceSize { get; set; }

        public double Duration { get; set; }


        //Relations: 

        public ICollection<HomeChefMealImages> homeChefMealImages { get; set; }

        public HomeChefs homeChefs { get; set; }

        public ICollection<HomeChefOrderMeals> homeChefOrderMeals { get; set; }





    }


    public class HomeChefMealsConfiguration : IEntityTypeConfiguration<HomeChefMeals>
    {
        public void Configure(EntityTypeBuilder<HomeChefMeals> builder)
        {
            builder.HasKey(homechefmeals => homechefmeals.Id);
            builder.Property(homechefmeals => homechefmeals.DishName).HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(homechefmeals => homechefmeals.Description).HasColumnType("NVARCHAR(max)").IsRequired(false);
            builder.Property(homechefmeals => homechefmeals.Price).HasColumnType("MONEY").IsRequired();
            builder.Property(homechefmeals => homechefmeals.AvailabilityStatus).HasColumnType("NVARCHAR(50)");
            builder.Property(homechefmeals => homechefmeals.DietaryTags).HasColumnType("NVARCHAR(max)");
            builder.Property(homechefmeals => homechefmeals.FoodCategory).HasDefaultValue("panding");
            builder.Property(homechefmeals => homechefmeals.PieceSize).HasDefaultValue("panding");



            //relation between HomeChefMeals & HomeChefMealImages (one to many)
            builder.HasMany(homechefmealimg => homechefmealimg.homeChefMealImages)
                .WithOne(homechefmeal => homechefmeal.homeChefMeals)
                .HasForeignKey(homechefmealimg => homechefmealimg.HomeChefMealsId)
                .OnDelete(DeleteBehavior.NoAction);


            //relation between HomeChefMeals & HomeChefOrderMeals (one to many)
            builder.HasMany(homechefordermeal => homechefordermeal.homeChefOrderMeals)
                .WithOne(homechefmeal => homechefmeal.homeChefMeals)
                .HasForeignKey(homechefordermeal => homechefordermeal.HomeChefMealsId);






        }
    }
}
