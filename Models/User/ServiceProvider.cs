using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.HomeService;

namespace Models.User
{
    public class ServiceProvider
    {
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public string? Image { get; set; }
        public List<string>? Skills { get; set; }//TODO
        public DateTime? StartProfisionalAt { get; set; }  
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? About { get; set; }
        public string? Licence { get; set; }
        public string? Certificate { get; set; }
        public VerificationStatus? VerificationStatus { get; set; }
        public int CategoryServicesId { get; set; }
        public virtual CategoryServices CategoryServices { get; set; }
        public virtual ICollection<ServiceProviderProject>? Projects { get; set; }
        public virtual ICollection<ServiceProviderSchedule>? Schedules { get; set; }
        public virtual ICollection<ServiceProviderPropsal>? Propsals { get; set; }
        public int? AverageRating { get; set; }
        public string? Website { get; set; }
        public decimal? Price { get; set; }
        public string? PriceUnit { get; set; }
    }
    public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.HasKey(sp =>  sp.UserId);

            builder.Property(sp => sp.Image)
                .HasMaxLength(255);

            builder.Property(sp => sp.About)
                .HasMaxLength(1000);

            builder.Property(sp => sp.Licence)
                .HasMaxLength(50);

            builder.Property(sp => sp.Certificate)
                .HasMaxLength(50);

            builder.HasOne(sp => sp.AppUser)
                .WithOne(cs => cs.ServiceProvider)
                .HasForeignKey<ServiceProvider>(sp => sp.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sp => sp.CategoryServices)
            .WithMany(cs => cs.ServiceProviders)
            .HasForeignKey(sp => sp.CategoryServicesId)
            .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(sp => sp.Schedules)
                .WithOne(s => s.ServiceProvider)
                .HasForeignKey(s => s.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
