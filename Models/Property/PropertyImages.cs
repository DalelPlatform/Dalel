using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class PropertyImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int PropertyId { get; set; } // fk With Properties
        public Properties Properties { get; set; }
    }

    public class PropertyImagesConfiguration : IEntityTypeConfiguration<PropertyImages>
    {
        public void Configure(EntityTypeBuilder<PropertyImages> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Image).HasMaxLength(256);
        }
    }
}
