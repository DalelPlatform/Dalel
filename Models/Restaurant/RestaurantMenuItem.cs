using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.Restaurant.Enums;

namespace Models.Restaurant
{
    public class RestaurantMenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public AvaliabilityStatus AvailabilityStatus { get; set; }
        public string DietaryTags { get; set; }
        public FoodCategory FoodCategory {  get; set; } // convert to int
        public SizeOfPiece PieceSize { get; set; }
        public double? Duration  { get; set; }
        public int RestaurantId { get; set; } //fk from Restaurant
        public bool IsDeleted { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<ProjectImages> RestaurantMenuItemImages { get; set; }
        public virtual ICollection<RestaurantOrderItem> RestaurantOrderItems { get; set; }
    }

    public class RestaurantMenuItemConfiguration : IEntityTypeConfiguration<RestaurantMenuItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantMenuItem> builder)
        {
            builder.HasKey(restmenuitem => restmenuitem.Id);
            builder.Property(restmenuitem => restmenuitem.FoodCategory).IsRequired();
            builder.Property(restmenuitem => restmenuitem.Description).HasColumnType("NVARCHAR(250)").HasDefaultValue("empty");
            builder.Property(restmenuitem => restmenuitem.PieceSize).IsRequired();
            builder.Property(restmenuitem => restmenuitem.Duration).IsRequired(false);
            builder.Property(restmenuitem => restmenuitem.Name).IsRequired().HasColumnType("NVARCHAR(50)");

            //Relation between RestuarantMenuItems & RestaurantMenuItemImage one to many
            builder
                .HasOne(restmenuitemimg => restmenuitemimg.Restaurant)
                .WithMany(restmenuitem => restmenuitem.RestaurantMenuItem)
                .HasForeignKey(restmenuitemimg => restmenuitemimg.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
