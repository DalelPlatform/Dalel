using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.Hotel
{
    public class HotelPolicy
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int PolicyId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Policy Policy { get; set; }
    }


    public class HotelPolicyConfiguration : IEntityTypeConfiguration<HotelPolicy>
    {
        public void Configure(EntityTypeBuilder<HotelPolicy> builder)
        {
            builder.ToTable("HotelPolicies");
            builder.HasKey(hp => hp.Id);

            builder.HasOne(hp => hp.Hotel)
                   .WithMany(h => h.HotelPolicies)
                   .HasForeignKey(hp => hp.HotelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(hp => hp.Policy)
                   .WithMany(a=>a.HotelPolicies) // Optionally, if Policy had a collection, use .WithMany(p => p.HotelPolicies)
                   .HasForeignKey(hp => hp.PolicyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
