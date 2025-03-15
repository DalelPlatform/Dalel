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
    public class PackageSchadule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SlotsAvailable { get; set; }
        public VerificationStatus Status { get; set; }
        public int PackageId { get; set; }
        public AgencyPackage AgencyPackage { get; set; }

        public ICollection <PackageBooking> PabckageBookings { get; set; }

    }
}

public class PackageSchaduleConfigration : IEntityTypeConfiguration<PackageSchadule>
{
    public void Configure(EntityTypeBuilder<PackageSchadule> modelBuilder)
    {
        modelBuilder.HasKey(PackgeSchadule => PackgeSchadule.Id);
        modelBuilder.HasOne(PackgeSchadule => PackgeSchadule.AgencyPackage)
        .WithMany(agencyPacge => agencyPacge.PackageSchadules)
        .HasForeignKey(PackgeSchadule => PackgeSchadule.PackageId);

    }
}