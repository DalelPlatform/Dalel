using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

namespace Models.Driver
{
    public class CarProposal
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public ProposalStatus ProposalStatus { get; set; }
        public bool IsAccepted { get; set; }
        public decimal SuggestedPrice { get; set; }
        public DateTime StartedDateTime { get; set; }
        public string DriverId { get; set; }
        public int BookingVehicleId { get; set; }
        public virtual Drivers Driver { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }

    public class CarProposalConfiguration : IEntityTypeConfiguration<CarProposal>
    {
        public void Configure(EntityTypeBuilder<CarProposal> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Price).HasColumnType("money").IsRequired();
            builder.Property(cp => cp.SuggestedPrice).HasColumnType("decimal(18,2)").IsRequired();

            // Relation with Driver (One-to-Many)
            builder.HasOne(cp => cp.Driver)
                   .WithMany(d => d.Proposals)
                   .HasForeignKey(cp => cp.DriverId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction); // منع الحذف التلقائي

            // Relationship with BookingVehicle (One-to-Many)
            builder.HasOne(cp => cp.BookingVehicle)
                   .WithMany(bv => bv.CarProposals)
                   .HasForeignKey(cp => cp.BookingVehicleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction); // منع الحذف التلقائي
        }
    }

}
