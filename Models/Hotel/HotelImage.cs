using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.Hotel
{
    public class HotelImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int HotelId { get; set; }

        // Navigation property
        public virtual Hotel Hotel { get; set; }
    }


    public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
    {
        public void Configure(EntityTypeBuilder<HotelImage> builder)
        {
            builder.ToTable("HotelImages");
            builder.HasKey(hi => hi.Id);

            builder.HasOne(hi => hi.Hotel)
                   .WithMany(h => h.HotelImages)
                   .HasForeignKey(hi => hi.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
