using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Restaurant.Enums;

namespace Models.Restaurant
{
    public class RestaurantMenuItem
    {
        public int Id { get; set; }

        public CategoriesOfFood FoodCategory {  get; set; } // convert to int

        public string Description { get; set; }
        public SizeOfPiece PieceSize { get; set; }

        public double? Duration  { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public int RestaurantId { get; set; } //fk from Restaurant


        //Relations :
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<RestaurantMenuItemImage> RestaurantMenuItemImage { get; set; }
    }

    public class RestaurantMenuItemsConfiguration : IEntityTypeConfiguration<RestaurantMenuItem>
    {
        public void Configure(EntityTypeBuilder<RestaurantMenuItem> builder)
        {
            builder.HasKey(restmenuitem => restmenuitem.Id);
            builder.Property(restmenuitem => restmenuitem.FoodCategory).HasDefaultValue("drink");
            builder.Property(restmenuitem => restmenuitem.Description).HasColumnType("NVARCHAR(250)").HasDefaultValue("empty");
            builder.Property(restmenuitem => restmenuitem.PieceSize).HasDefaultValue("small");
            builder.Property(restmenuitem => restmenuitem.Duration).IsRequired(false);
            builder.Property(restmenuitem => restmenuitem.Name).IsRequired(false).HasColumnType("NVARCHAR(50)");
            builder.Property(restmenuitem => restmenuitem.Name).IsRequired();

            //Relation between RestuarantMenuItems & RestaurantMenuItemImage one to many
            builder.HasMany(restmenuitemimg => restmenuitemimg.RestaurantMenuItemImage)
                .WithOne(restmenuitem => restmenuitem.RestaurantMenuItem)
                .HasForeignKey(restmenuitemimg => restmenuitemimg.RestaurantMenuItemId)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
