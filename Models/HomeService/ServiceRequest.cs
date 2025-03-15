using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.HomeService.ENUMS;
using Models.User;

namespace Models.HomeService
{
    public class ServiceRequest
    {
        //aprove proposal
        
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public RequestStatusEnum Status { get; set; }
        public double StartPrice { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? Image { get; set; }

        //relation with cat
        public virtual Client Client { get; set; }
        public virtual ICollection<ServiceProviderPropsal> Propsals { get; set; } 
        
    }
    public class ServiceProviderBookingConfiguration : IEntityTypeConfiguration<ServiceRequest>
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

            builder.HasMany(sb => sb.Propsals)
                .WithOne(sp => sp.ServiceRequest)
                .HasForeignKey(sp => sp.ServiceRequestId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
