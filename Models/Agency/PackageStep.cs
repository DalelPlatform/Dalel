using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;

namespace Models.Agency
{
    public class PackageStep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float? Duration { get; set; } 
        public string? Image { get; set; }
        public int PackageId { get; set; }
        public virtual AgencyPackage AgencyPackage { get; set; }
    }
}

public class PackageStepConfigration : IEntityTypeConfiguration<PackageStep>
{
    public void Configure(EntityTypeBuilder<PackageStep> modelBuilder)
    {
        modelBuilder.HasKey(PackgeStep => PackgeStep.Id);
        modelBuilder.HasOne(PackgeStep => PackgeStep.AgencyPackage)
        .WithMany(agencyPacge => agencyPacge.PackageSteps)
        .HasForeignKey(PackgeStep => PackgeStep.PackageId).OnDelete(DeleteBehavior.NoAction);


    }
}
