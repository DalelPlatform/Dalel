using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Enums;

namespace Models.Agency
{
    public class AgencyVerificationDocument
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentFile { get; set; }
        public virtual VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
        public virtual TravelAgencies Agency { get; set; }

    }
}

public class AgencyVerificationDocumentConfigration : IEntityTypeConfiguration<AgencyVerificationDocument>
{
    public void Configure(EntityTypeBuilder<AgencyVerificationDocument> modelBuilder)
    {

        modelBuilder.HasKey(verify => verify.Id);
        modelBuilder.HasOne(verify => verify.Agency)
        .WithMany(agency => agency.AgencyVerificationDocuments)
        .HasForeignKey(verify => verify.AgencyId);

    }
}
