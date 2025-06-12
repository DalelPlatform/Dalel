using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.User;
using Models.Enums;

namespace Models.HomeService
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public DateTime Date { get; set; }
        public RequestStatus Status { get; set; }
        public bool IsDeleted { get; set; } 
        public double StartPrice { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? Image { get; set; }
        public int CategoryServicesId { get; set; } 
        public virtual Client Client { get; set; }
        public virtual ServiceProviderReview Review { get; set; }
        public virtual ServiceProviderPayment Payment { get; set; }
        public virtual ICollection<ServiceProviderPropsal> Propsals { get; set; }
    }
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> builder)
        {
            builder.HasKey(sr => sr.Id);

            builder.Property(sr => sr.Description)
                .HasMaxLength(500);

            builder.Property(sr => sr.Address)
                .HasMaxLength(255);

           builder.HasOne(c=>c.Client)
                .WithMany(sr => sr.ServiceRequests)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
