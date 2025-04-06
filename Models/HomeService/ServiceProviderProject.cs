using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;

namespace Models.HomeService
{
    public class ServiceProviderProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectImages { get; set; }
        public string ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual ICollection<ServiceProviderProjectImages> ServiceProviderProjectImages { get; set; }
    }

    public class ServiceProviderProjectConfiguration : IEntityTypeConfiguration<ServiceProviderProject>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderProject> builder)
        {
            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pp => pp.Description)
                .HasMaxLength(1000);

            // Consider removing this if using separate images table
            builder.Property(pp => pp.ProjectImages)
                .HasMaxLength(255);

            builder.HasOne(pp => pp.ServiceProvider)
                .WithMany(sp => sp.Projects)
                .HasForeignKey(pp => pp.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Navigation property configuration
            builder.HasMany(pp => pp.ServiceProviderProjectImages)
                .WithOne(i => i.ServiceProviderProject)
                .HasForeignKey(i => i.ServiceProviderProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}