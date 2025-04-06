using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Restaurant
{
    public class ProjectImages
    {
        public int Id { get; set; } //pk

        public string Image {  get; set; }

        public int RestaurantMenuItemId { get; set; } //fk

        //Relations :
        public virtual RestaurantMenuItem RestaurantMenuItem {  get; set; } 
    }


    public class RestaurantMenuItemImageConfiguration : IEntityTypeConfiguration<ProjectImages>
    {
        public void Configure(EntityTypeBuilder<ProjectImages> builder)
        {
            builder.HasKey(restmenuitemimgs => restmenuitemimgs.Id);
            builder.Property(restmenuitemimgs => restmenuitemimgs.Image).HasColumnType("NVARCHAR(max)");

            builder.HasOne(i => i.RestaurantMenuItem)
                .WithMany(i => i.RestaurantMenuItemImages)
                .HasForeignKey(i => i.RestaurantMenuItemId);

        }
    }
}
