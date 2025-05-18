using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.HomeChef
{
    public class HomeChefMealImage
    {
        public int Id { get; set; }
        public string Image {  get; set; }
        public int HomeChefMealsId { get; set; } //fk
        public virtual HomeChefMeal HomeChefMeal { get; set; }

    }


    public class HomeChefMealImageConfiguration : IEntityTypeConfiguration<HomeChefMealImage>
    {
        public void Configure(EntityTypeBuilder<HomeChefMealImage> builder)
        {
            builder.HasKey(homechefmealimg => homechefmealimg.Id);
            builder.Property(homechefmealimg => homechefmealimg.Image).HasColumnType("NVARCHAR(max)");

            builder.HasOne(p => p.HomeChefMeal)
            .WithMany(p => p.HomeChefMealImages)
            .HasForeignKey(p => p.HomeChefMealsId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
