using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class RestaurantMenuItemImages
    {
        public int Id { get; set; } //pk

        public string Image {  get; set; }

        public int RestaurantMenuItemId { get; set; } //fk

        //Relations :
        public RestaurantMenuItems RestaurantMenuItems {  get; set; } 
    }


    public class RestaurantMenuItemImagesConfiguration : IEntityTypeConfiguration<RestaurantMenuItemImages>
    {
        public void Configure(EntityTypeBuilder<RestaurantMenuItemImages> builder)
        {
            builder.HasKey(restmenuitemimgs => restmenuitemimgs.Id);
            builder.Property(restmenuitemimgs => restmenuitemimgs.Image).HasColumnType("NVARCHAR(max)");

        }
    }
}
