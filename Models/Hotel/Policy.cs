using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel
{
    public class Policy
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }  // Enum as int
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
