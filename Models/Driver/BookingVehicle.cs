using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

namespace Models.Driver
{
    public class BookingVehicle
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public decimal SuggestedPrice { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int PassengersNo { get; set; }
        public DateTime StartedDateTime { get; set; }
        public DateTime EndedDateTime { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<CarProposal> CarProposals { get; set; }
        public virtual PaymentVehicle Payment { get; set; }
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

            builder.HasOne(p => p.Client)
            .WithMany(p => p.BookingVehicles)
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
