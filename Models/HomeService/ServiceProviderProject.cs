using Microsoft.AspNetCore.Http;
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
        public decimal ApproximatePrice { get; set; }
        public string PriceUnit { get; set; }
        public string ServiceProviderId { get; set; }
        public string? Image { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }

    public class ServiceProviderProjectConfiguration : IEntityTypeConfiguration<ServiceProviderProject>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderProject> builder)
        {
            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Name).IsRequired().HasMaxLength(100);
            builder.Property(pp => pp.Description).IsRequired().HasMaxLength(1000);
            builder.Property(pp => pp.ApproximatePrice).IsRequired();
            builder.Property(pp => pp.PriceUnit).IsRequired().HasMaxLength(50);
            builder.Property(sp => sp.Image).HasMaxLength(255);

            builder.HasOne(pp => pp.ServiceProvider)
                .WithMany(sp => sp.Projects)
                .HasForeignKey(pp => pp.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}