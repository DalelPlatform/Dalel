using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.Hotel
{
    public class HotelService
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int HotelId { get; set; }
        public int ServicesId { get; set; }

        // Navigation properties
        public virtual Hotel Hotel { get; set; }
        public virtual Service Service { get; set; }
    }

    public class HotelServiceConfiguration : IEntityTypeConfiguration<HotelService>
    {
        public void Configure(EntityTypeBuilder<HotelService> builder)
        {
            builder.ToTable("HotelServices");
            builder.HasKey(hs => hs.Id);
            builder.Property(hs => hs.Price).HasDefaultValue(0);

            builder.HasOne(hs => hs.Hotel)
                   .WithMany(h => h.HotelServices)
                   .HasForeignKey(hs => hs.HotelId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(hs => hs.Service)
                   .WithMany(a=>a.HotelServices) // If Service had a collection, use .WithMany(s => s.HotelServices)
                   .HasForeignKey(hs => hs.ServicesId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
