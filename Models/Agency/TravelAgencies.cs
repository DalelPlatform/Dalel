using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Agency;
using Models.Enums;
using Models.User;

namespace Models.Agency
{
    public class TravelAgencies
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string BusinessCategory { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int BuildingNo { get; set; }
        public string Street { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModificationDate    { get; set; }
        public string OwnerId { get; set; }
        public virtual TravelAgencyOwners travelAgencyOwners { get; set; }
        public virtual ICollection<AgencyPackage> AgencyPackages { get; set; }
        public virtual ICollection<AgencyVerificationDocument> AgencyVerificationDocuments { get; set; }
        public virtual ICollection <AgencyPromotion> agencyPromotions { get; set; }
   
    }
}

public class TravelAgencyConfugeration : IEntityTypeConfiguration<TravelAgencies>
{
    public void Configure(EntityTypeBuilder<TravelAgencies> modelBuilder)
    {
        modelBuilder.HasKey(t => t.Id);
        modelBuilder.Property(t => t.Description).HasColumnType("NVARCHAR(MAX)");
        modelBuilder.Property(t => t.City).HasColumnType("NVARCHAR(MAX)");
        modelBuilder.Property(t => t.Street).HasColumnType("NVARCHAR(MAX)");
        modelBuilder.Property(t => t.ModificationDate).HasColumnType("DATETIME2(7)");
        modelBuilder.Property(t => t.OwnerId).HasColumnType("nvarchar(450)");
        modelBuilder.HasOne(trvel => trvel.travelAgencyOwners)
            .WithMany(trvel_owner => trvel_owner.TravelAgencies)
            .HasForeignKey(trvel => trvel.OwnerId);
    }
}