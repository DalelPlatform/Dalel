using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

namespace Models.HomeService
{
    public class ServiceProviderPropsal
    {
        public int Id { get; set; }
        public string ServiceProviderId { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public double SuggestedPrice { get; set; }
        public string Description { get; set; }
        public ProposalStatus Status { get; set; }  
        public int ServiceRequestId { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }

    public class ServiceProviderPropsalConfiguration : IEntityTypeConfiguration<ServiceProviderPropsal>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderPropsal> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.Description)
                .HasMaxLength(500);

            builder.HasOne(sp => sp.ServiceRequest)
                .WithMany(sr => sr.Propsals)
                .HasForeignKey(sp => sp.ServiceRequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sp => sp.ServiceProvider)
                .WithMany(sr => sr.Propsals)
                .HasForeignKey(sp => sp.ServiceProviderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(sp => sp.SuggestedPrice)
                .HasColumnType("decimal(18,2)");
        }
    }
}
