using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Property;


namespace Models.User
{
    public class PropertyOwner
    {
        public string UserId { get; set; } //fk & pk
        public AppUser AppUser { get; set; }

        public bool IsDeleted { get; set; }

        //Relation
        public virtual Properties Properties { get; set; }

        
    }

    public class PropertyOwnerConfiguration : IEntityTypeConfiguration<PropertyOwner>
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            builder.HasKey(PropertyOwner => PropertyOwner.UserId);


        }
    }
}
