using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;

namespace Models.HomeChef
{
    public class HomeChefMeal
    {
        public int Id { get; set; }
        public string HomeChefId { get; set; } //fk
        public string DishName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool AvailabilityStatus { get; set; }
        public string DietaryTags { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public SizeOfPiece PieceSize { get; set; }
        public double? Duration { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<HomeChefMealImage> HomeChefMealImages { get; set; }
        public virtual User.HomeChef HomeChef { get; set; }
        public virtual ICollection<HomeChefOrderMeal> HomeChefOrderMeals { get; set; }
    }


    public class HomeChefMealConfiguration : IEntityTypeConfiguration<HomeChefMeal>
    {
        public void Configure(EntityTypeBuilder<HomeChefMeal> builder)
        {
            builder.HasKey(homechefmeals => homechefmeals.Id);
            builder.Property(homechefmeals => homechefmeals.DishName).HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(homechefmeals => homechefmeals.Description).HasColumnType("NVARCHAR(max)").IsRequired(false);
            builder.Property(homechefmeals => homechefmeals.Price).HasColumnType("MONEY").IsRequired();
            builder.Property(homechefmeals => homechefmeals.DietaryTags).HasColumnType("NVARCHAR(max)");
        }
    }
}
