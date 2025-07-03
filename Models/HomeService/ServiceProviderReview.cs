using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;

namespace Models.HomeService
{
    public class ServiceProviderReview
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ServiceProviderId { get; set; }
        public string ClientId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual Client Client { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
    }
    public class ServiceProviderReviewConfiguration : IEntityTypeConfiguration<ServiceProviderReview>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderReview> builder)
        {
            builder.HasKey(sr => sr.Id);
            builder.Property(sr => sr.Review)
                .HasMaxLength(1000);

            builder.HasOne(sr => sr.ServiceRequest)
                .WithOne(sb => sb.Review)
                .HasForeignKey<ServiceProviderReview>(sr => sr.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(sr => sr.ServiceProvider)
                .WithMany(sp => sp.Reviews)
                .HasForeignKey(sr => sr.ServiceProviderId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(sr => sr.Client)
                .WithMany(c => c.ServiceProviderReviews)
                .HasForeignKey(sr => sr.ClientId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
