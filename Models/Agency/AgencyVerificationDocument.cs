using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Agency.Enums;

namespace Models.Agency
{
    public class AgencyVerificationDocument
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }

        public string DocumentFile { get; set; }

        public VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
        public TravelAgencies Agency { get; set; }

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
