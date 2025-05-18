using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.HomeChef
{
    public class HomeChefOrderMeal
    {
        public int Id { get; set; }
        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public int HomeChefOrdersId { get; set; }//fk
        public int HomeChefMealsId { get; set; }//fk

        public virtual HomeChefOrder HomeChefOrder { get; set; }
        public virtual HomeChefMeal HomeChefMeal { get; set; }

    }

    public class HomeChefOrderMealConfiguration : IEntityTypeConfiguration<HomeChefOrderMeal>
    {
        public void Configure(EntityTypeBuilder<HomeChefOrderMeal> builder)
        {
            builder.HasKey(homechefordermeal => homechefordermeal.Id);
            builder.Property(homechefordermeal => homechefordermeal.SupPrice).HasColumnType("MONEY");

            builder.HasOne(p => p.HomeChefOrder)
                .WithMany(p => p.HomeChefOrderMeals)
                .HasForeignKey(p => p.HomeChefOrdersId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.HomeChefMeal)
             .WithMany(p => p.HomeChefOrderMeals)
             .HasForeignKey(p => p.HomeChefMealsId)
             .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
