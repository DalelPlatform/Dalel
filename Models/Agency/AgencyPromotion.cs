using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Agency.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models.Agency
{
    public class AgencyPromotion
    {
        public int Id { get; set; }
        public float DiscountPercentage { get; set; }
   public DateTime StartDate { get; set; }
        public VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
        public TravelAgencies Agency { get; set; }
    }
}

public class AgencyPromotionConfigration : IEntityTypeConfiguration<AgencyPromotion>
{
    public void Configure(EntityTypeBuilder<AgencyPromotion> modelBuilder)
    {

        modelBuilder.HasKey(promot => promot.Id);
        modelBuilder.HasOne(verify => verify.Agency)
        .WithMany(agency => agency.agencyPromotions)
        .HasForeignKey(promot => promot.AgencyId);

    }
}
