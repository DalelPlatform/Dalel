using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;

namespace Models.HomeService
{
    public class CategoryServices
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
        public virtual ICollection<ServiceQuaries> Quaries { get; set; }
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


        }
    }
}
