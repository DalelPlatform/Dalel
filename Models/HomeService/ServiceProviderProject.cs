using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class ServiceProviderProject
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectImage { get; set; }
        public string ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }
    public class ServiceProviderProjectConfiguration : IEntityTypeConfiguration<ServiceProviderProject>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderProject> builder)
        {
            builder.HasKey(pp => pp.Id);
            builder.Property(pp => pp.ProjectName)
                .HasMaxLength(50);

            builder.Property(pp => pp.ProjectDescription)
                .HasMaxLength(1000);

            builder.Property(pp => pp.ProjectImage)
                .HasMaxLength(255);

            builder.HasOne(pp => pp.ServiceProvider)
                .WithMany(sp => sp.Projects)
                .HasForeignKey(pp => pp.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
