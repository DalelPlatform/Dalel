using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Models.Hotel
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<HotelService> HotelServices { get; set; }
    }

    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service"); // Map the entity to the "Amenities" table

            // Primary Key Configuration
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .UseIdentityColumn(); // Configure auto-incrementing identity

            // Property Configurations
            builder.Property(a => a.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(a => a.Description)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(a => a.IsActive)
                .HasDefaultValue(true);
        }
    }
}
