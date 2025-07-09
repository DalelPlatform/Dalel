using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Models.Notification;
using Models.User;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceProvider = Models.User.ServiceProvider;

namespace Models.Notification
{
    public class ServicesNotifications
    {
        public int Id { get; set; }

        public string ServiceProviderId { get; set; }
        public string ClientId { get; set; }
        public int RequestId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual Client Client { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }


    }

}
public class ServicesNotificationsConfiguration : IEntityTypeConfiguration<ServicesNotifications>
{
    public void Configure(EntityTypeBuilder<ServicesNotifications> modelBuilder)
    {
        modelBuilder.HasKey(sn => sn.Id);

        modelBuilder.HasOne(sn => sn.ServiceProvider)
            .WithMany() 
            .HasForeignKey(sn => sn.ServiceProviderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasOne(sn => sn.Client)
            .WithMany() 
            .HasForeignKey(sn => sn.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasOne(sn => sn.ServiceRequest)
            .WithMany() 
            .HasForeignKey(sn => sn.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        
        modelBuilder.Property(sn => sn.Message)
            .IsRequired()
            .HasMaxLength(1000);

        modelBuilder.Property(sn => sn.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
    }
}

