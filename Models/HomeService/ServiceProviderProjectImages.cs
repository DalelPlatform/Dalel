using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models.HomeService
{
    public class ServiceProviderProjectImages
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ServiceProviderProjectId { get; set; }
        public virtual ServiceProviderProject ServiceProviderProject { get; set; }
    }

    public class ServiceProviderProjectImagesConfiguration : IEntityTypeConfiguration<ServiceProviderProjectImages>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderProjectImages> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImagePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(i => i.ServiceProviderProject)
                .WithMany(p => p.ServiceProviderProjectImages)
                .HasForeignKey(i => i.ServiceProviderProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}