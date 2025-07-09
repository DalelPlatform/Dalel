using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Enums;

namespace Models.Agency
{
    public class AgencyPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Duration { get; set; }
        public float Price { get; set; }
        public string TermsPolicies { get; set; }
        public string? ImagePath { get; set; }
        public int AgencyId { get; set; }
        public virtual VerificationStatus VerificationStatus { get; set; }
        public virtual TravelAgencies Agency { get; set; }
        public virtual ICollection<PackageStep> PackageSteps { get; set; }
        public virtual ICollection<PackageSchadule> PackageSchadules { get; set; }


    }
}

public class AgencyPackageConfigration : IEntityTypeConfiguration<AgencyPackage>
{
    public void Configure(EntityTypeBuilder<AgencyPackage> modelBuilder)
    { 
    modelBuilder.HasKey(Packge => Packge.Id);
        modelBuilder.HasOne(packge => packge.Agency)
        .WithMany(agency => agency.AgencyPackages)
        .HasForeignKey(agency => agency.AgencyId).OnDelete(DeleteBehavior.NoAction);

    }
}