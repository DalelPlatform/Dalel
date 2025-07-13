using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.User;

namespace Models.HomeService
{
    public class ServiceChat
    {
        public int Id { get; set; }
        public string ServiceProviderId { get; set; } 
        public string ClientId { get; set; }
        public DateTime LastMessageAt { get; set; }
        public virtual User.ServiceProvider ServiceProvider { get; set; }
        public virtual User.Client Client { get; set; }
        public virtual ICollection<ServiceQuaries> Quaries{ get; set; }

    }
    public class ServiceChatConfiguration : IEntityTypeConfiguration<ServiceChat>
    {
        public void Configure(EntityTypeBuilder<ServiceChat> builder)
        {
            // Primary Key
            builder.HasKey(sq => sq.Id);

            builder.HasOne(sq => sq.ServiceProvider)
                .WithMany(i => i.Chats)
                .HasForeignKey(sq => sq.ServiceProviderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sc => sc.Client)
                .WithMany(sq => sq.Chats)
                .HasForeignKey(sq => sq.ClientId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
