using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class ReviewProperties
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string ClientId { get; set; } // fk Client.UserId
        public int BookingPropertyId { get; set; } // fk BookingProperties.Id
        public bool IsDeleted { get; set; }


        //relations
        public virtual Client? Client { get; set; }
        public virtual BookingProperties BookingProperties { get; set; }
    }

    public class ReviewPropertiesConfiguration : IEntityTypeConfiguration<ReviewProperties>
    {
        public void Configure(EntityTypeBuilder<ReviewProperties> builder)
        {
            builder.HasKey(rp => rp.Id);
            builder.Property(rp => rp.Rating).HasColumnType("decimal(18,2)");
            builder.Property(rp => rp.Comments).HasMaxLength(500);
            //relations
            builder.HasOne(rp => rp.Client)
                .WithMany(c => c.ReviewProperties)
                .HasForeignKey(rp => rp.ClientId);
            builder.HasOne(rp => rp.BookingProperties)
                .WithMany(bp => bp.ReviewProperties)
                .HasForeignKey(rp => rp.BookingPropertyId);
        }
    }
}
