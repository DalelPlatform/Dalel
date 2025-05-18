using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.Property
{
    public class PropertyImages
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int PropertyId { get; set; } // fk With Properties
        public virtual Properties Properties { get; set; }
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
