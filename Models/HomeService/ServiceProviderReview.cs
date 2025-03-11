using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class ServiceProviderReview
    {
        public int Id { get; set; }
        public int ServiceProviderId { get; set; }
        public int ClientId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual ServiceProviderBooking ServiceProviderBooking { get; set; }
    }
    public class ServiceProviderReviewConfiguration : IEntityTypeConfiguration<ServiceProviderReview>
    {
        public void Configure(EntityTypeBuilder<ServiceProviderReview> builder)
        {
            builder.HasKey(sr => sr.Id);
            builder.Property(sr => sr.Review)
                .HasMaxLength(1000);
            builder.HasOne(sr => sr.ServiceProvider)
                .WithMany(sp => sp.Reviews)
                .HasForeignKey(sr => sr.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sr => sr.ServiceProviderBooking)
                .WithMany(sb => sb.Reviews)
                .HasForeignKey(sr => sr.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
