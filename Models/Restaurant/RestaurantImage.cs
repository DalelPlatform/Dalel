using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class RestaurantImage
    {
        public int Id { get; set; }
        public string Image {  get; set; }

        public int RestaurantId { get; set; } //fk from Restaurants


        //Relations :
        public virtual Restaurant Restaurant { get; set; }
    }


    public class RestaurantImageConfiguration : IEntityTypeConfiguration<RestaurantImage>
    {
        public void Configure(EntityTypeBuilder<RestaurantImage> builder)
        {
            builder.HasKey(restImg => restImg.Id);
            builder.Property(restImg => restImg.Image).HasColumnType("NVARCHAR(max)").HasDefaultValue("empty");

            builder.HasOne(i => i.Restaurant)
                .WithMany(r => r.RestaurantImages)
                .HasForeignKey(i => i.RestaurantId);

        }
    }
}
