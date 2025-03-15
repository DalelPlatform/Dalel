using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class ServiceProvider
    {
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Image { get; set; }
        public List<string> Skills { get; set; }
        public DateTime StartProfisionalAt { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public string About { get; set; }
        public string Licence { get; set; }
        public string Certificate { get; set; }
        public int CategoryServicesId { get; set; }
        public virtual CategoryServices CategoryServices { get; set; }
        public virtual ICollection<ServiceProviderProject> Projects { get; set; }
        public virtual ICollection<ServiceRequest> Requests { get; set; }
        public virtual ICollection<ServiceProviderReview> Reviews { get; set; }
        public ServiceProviderPropsal Propsals { get; internal set; }
    }
    public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.HasKey(sp =>  new {sp.UserId, sp.CategoryServicesId });

            builder.Property(sp => sp.Image)
                .HasMaxLength(255);

            builder.Property(sp => sp.About)
                .HasMaxLength(1000);

            builder.Property(sp => sp.Licence)
                .HasMaxLength(50);

            builder.Property(sp => sp.Certificate)
                .HasMaxLength(50);

            builder.HasOne(sp => sp.CategoryServices)
                .WithMany(cs => cs.ServiceProviders)
                .HasForeignKey(sp => sp.CategoryServicesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sp => sp.Projects)
                .WithOne(pp => pp.ServiceProvider)
                .HasForeignKey(pp => pp.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);



            builder.HasMany(sp => sp.Reviews)
                .WithOne(sr => sr.ServiceProvider)
                .HasForeignKey(sr => sr.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
