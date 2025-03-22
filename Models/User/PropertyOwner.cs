using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Property;


namespace Models.User
{
    public class PropertyOwner
    {
        public string UserId { get; set; } //fk & pk
        public virtual AppUser AppUser { get; set; }
        //Relation
        public virtual ICollection<Properties> Properties { get; set; }
    }

    public class PropertyOwnerConfiguration : IEntityTypeConfiguration<PropertyOwner>
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            builder.HasKey(PropertyOwner => PropertyOwner.UserId);

            builder
                .HasOne(a => a.AppUser)
                .WithOne(a => a.PropertyOwner)
                .HasForeignKey<PropertyOwner>(a => a.UserId);
        }
    }
}
