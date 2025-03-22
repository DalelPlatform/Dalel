using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.User
{
    public class HotelOwners
    {
        public string UserId { get; set; } // fk & pk

        public virtual AppUser AppUser { get; set; }
         
        public virtual Hotel.Hotel Hotel { get; set; }
    }

    public class HotelOwnersConfiguration : IEntityTypeConfiguration<HotelOwners>
    {
        public void Configure(EntityTypeBuilder<HotelOwners> builder)
        {
            builder.HasKey(hotelowners => hotelowners.UserId);

            builder.HasOne(b => b.AppUser)
                .WithOne(a => a.HotelOwner)
                .HasForeignKey<HotelOwners>(o => o.UserId);
        }
    }
}
