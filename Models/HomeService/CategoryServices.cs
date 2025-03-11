using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class CategoryServices
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; } = new List<ServiceProvider>();
        public virtual ICollection<ServiceQuaries> Quaries { get; set; } = new List<ServiceQuaries>();
    }

    public class CategoryServicesConfiguration : IEntityTypeConfiguration<CategoryServices>
    {
        public void Configure(EntityTypeBuilder<CategoryServices> builder)
        {
            builder.HasKey(cs => cs.Id);

            builder.Property(cs => cs.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(cs => cs.Image)
                .HasMaxLength(255);

            builder.Property(cs => cs.Description)
                .HasMaxLength(500);

            builder.HasMany(cs => cs.ServiceProviders)
                .WithOne(sp => sp.CategoryServices)
                .HasForeignKey(sp => sp.CategoryServicesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(cs => cs.Quaries)
                .WithOne(sq => sq.CategoryServices)
                .HasForeignKey(sq => sq.CategoryServicesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new CategoryServices { Id = 1, Name = "Plumbing", Description = "Plumbing services" },
                new CategoryServices { Id = 2, Name = "Electrical", Description = "Electrical services" }
            );
        }
    }
}
