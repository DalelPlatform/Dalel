using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Models.User
{
    public class PropertyOwners
    {
        public string UserId { get; set; } //fk & pk
        public AspDotNetUsers AspDotNetUsers { get; set; }

        
    }

    public class PropertyOwnersConfiguration : IEntityTypeConfiguration<PropertyOwners>
    {
        public void Configure(EntityTypeBuilder<PropertyOwners> builder)
        {
            builder.HasKey(PropertyOwners => PropertyOwners.UserId);


        }
    }
}
