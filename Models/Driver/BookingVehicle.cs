using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Driver
{
    public class BookingVehicle
    {
        public int Id { get; set; }


        public string PickupLocation { get; set; }


        public string DropoffLocation { get; set; }

        public decimal SuggestedPrice { get; set; }


        public int Status { get; set; }

        public int PassengersNo { get; set; }


        public DateTime StartedDateTime { get; set; }

        public DateTime EndedDateTime { get; set; }


        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<CarProposal> CarProposals { get; set; }


        // One-to-One Relationship with PaymentVehicle
        public virtual PaymentVehicle Payment { get; set; }

        // One-to-One Relationship with ReviewVehicle
        public virtual ReviewVehicle Review { get; set; }


    }

    public class BookingVehicleConfiguration : IEntityTypeConfiguration<BookingVehicle>
    {
        public void Configure(EntityTypeBuilder<BookingVehicle> builder)
        {
            builder.HasKey(bv => bv.Id);
            builder.Property(bv => bv.PickupLocation).IsRequired().HasMaxLength(255);
            builder.Property(bv => bv.DropoffLocation).IsRequired().HasMaxLength(255);
            builder.Property(bv => bv.SuggestedPrice).HasColumnType("decimal(18,2)").IsRequired();

            // Relationship with Client
            builder.HasOne(b => b.Client)
                   .WithMany(B=>B.BookingVehicles)
                   .HasForeignKey(b => b.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-One Relationship with PaymentVehicle
            builder.HasOne(b => b.Payment)
                   .WithOne(p => p.BookingVehicle)
                   .HasForeignKey<PaymentVehicle>(p => p.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-One Relationship with ReviewVehicle
            builder.HasOne(b => b.Review)
                   .WithOne(r => r.BookingVehicle)
                   .HasForeignKey<ReviewVehicle>(r => r.Id)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many Relationship with CarProposal
            builder.HasMany(b => b.CarProposals)
                   .WithOne(cp => cp.BookingVehicle)
                   .HasForeignKey(cp => cp.BookingVehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
