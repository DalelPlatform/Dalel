using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Enums;

namespace Models.Agency
{
    public class AgencyPromotion
    {
        public int Id { get; set; }
        public float DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } //null untill owner deactive it
        public VerificationStatus status { get; set; }
        public int AgencyId { get; set; }
        public virtual TravelAgencies Agency { get; set; }
    }
}

public class AgencyPromotionConfigration : IEntityTypeConfiguration<AgencyPromotion>
{
    public void Configure(EntityTypeBuilder<AgencyPromotion> modelBuilder)
    {

        modelBuilder.HasKey(promot => promot.Id);
        modelBuilder.Property(p => p.StartDate).HasDefaultValueSql("GetDate()");
        modelBuilder.Property(p => p.EndDate).IsRequired(false);
        modelBuilder.HasOne(verify => verify.Agency)
        .WithMany(agency => agency.agencyPromotions)
        .HasForeignKey(promot => promot.AgencyId).OnDelete(DeleteBehavior.NoAction);

    }
}
