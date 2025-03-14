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
    public class HomeChefMeal
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

        public bool IsDeleted { get; set; }


        //Relations: 

        public virtual ICollection<HomeChefMealImage> HomeChefMealImage { get; set; }

        public virtual User.HomeChef HomeChef { get; set; }

        public virtual ICollection<HomeChefOrderMeal> HomeChefOrderMeal { get; set; }





    }


    public class HomeChefMealConfiguration : IEntityTypeConfiguration<HomeChefMeal>
    {
        public void Configure(EntityTypeBuilder<HomeChefMeal> builder)
        {
            builder.HasKey(homechefmeals => homechefmeals.Id);
            builder.Property(homechefmeals => homechefmeals.DishName).HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(homechefmeals => homechefmeals.Description).HasColumnType("NVARCHAR(max)").IsRequired(false);
            builder.Property(homechefmeals => homechefmeals.Price).HasColumnType("MONEY").IsRequired();
            builder.Property(homechefmeals => homechefmeals.AvailabilityStatus).HasColumnType("NVARCHAR(50)");
            builder.Property(homechefmeals => homechefmeals.DietaryTags).HasColumnType("NVARCHAR(max)");
            builder.Property(homechefmeals => homechefmeals.FoodCategory).HasDefaultValue("Panding");
            builder.Property(homechefmeals => homechefmeals.PieceSize).HasDefaultValue("Panding");



            //relation between HomeChefMeal & HomeChefMealImage (one to many)
            builder.HasMany(homechefmealimg => homechefmealimg.HomeChefMealImage)
                .WithOne(homechefmeal => homechefmeal.HomeChefMeal)
                .HasForeignKey(homechefmealimg => homechefmealimg.HomeChefMealsId)
                .OnDelete(DeleteBehavior.NoAction);


            //relation between HomeChefMeal & HomeChefOrderMeal (one to many)
            builder.HasMany(homechefordermeal => homechefordermeal.HomeChefOrderMeal)
                .WithOne(homechefmeal => homechefmeal.HomeChefMeal)
                .HasForeignKey(homechefordermeal => homechefordermeal.HomeChefMealsId);






        }
    }
}
