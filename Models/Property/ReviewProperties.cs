using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;

namespace Models.Property
{
    public class ReviewProperties
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public int BookingPropertyId { get; set; } // fk BookingProperties.Id
        public virtual BookingProperties BookingProperties { get; set; }
    }

    public class ReviewPropertiesConfiguration : IEntityTypeConfiguration<ReviewProperties>
    {
        public void Configure(EntityTypeBuilder<ReviewProperties> builder)
        {
            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.Rating).HasColumnType("decimal(18,2)");
            builder.Property(rp => rp.Comments).HasMaxLength(500);
            
            builder.HasOne(rp => rp.BookingProperties)
                .WithOne(bp => bp.ReviewProperties)
                .HasForeignKey<ReviewProperties>(rp => rp.BookingPropertyId);
        }
    }
}
