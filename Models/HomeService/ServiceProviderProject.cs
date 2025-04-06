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
        public string Image { get; set; }
        public string ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }
    public class ServiceProviderProjectConfiguration : IEntityTypeConfiguration<ServiceProviderProject>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderProject> builder)
        {
            builder.HasKey(pp => pp.Id);
            builder.Property(pp => pp.Name)
                .HasMaxLength(50);

            builder.Property(pp => pp.Description)
                .HasMaxLength(1000);

            builder.Property(pp => pp.Image)
                .HasMaxLength(255);

            builder.HasOne(pp => pp.ServiceProvider)
                .WithMany(sp => sp.Projects)
                .HasForeignKey(pp => pp.ServiceProviderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
