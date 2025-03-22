using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Enums;

namespace Models.Hotel
{
    public class Policy
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public PolicyType Type { get; set; }  // Enum as int

        public virtual ICollection<HotelPolicy> HotelPolicies { get; set; }

    }


    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.ToTable("Policy");
            builder.HasKey(p => p.Id);
            // Further configuration as needed.
        }
    }

}
