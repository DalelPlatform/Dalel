using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class RestaurantImages
    {
        public int Id { get; set; }
        public string Image {  get; set; }

        public int RestaurantId { get; set; } //fk from Restaurants


        //Relations :
        public Restaurants restaurants { get; set; }
    }


    public class RestaurantImagesConfiguration : IEntityTypeConfiguration<RestaurantImages>
    {
        public void Configure(EntityTypeBuilder<RestaurantImages> builder)
        {
            builder.HasKey(restImg => restImg.Id);
            builder.Property(restImg => restImg.Image).HasColumnType("NVARCHAR(max)").HasDefaultValue("empty");

        }
    }
}
