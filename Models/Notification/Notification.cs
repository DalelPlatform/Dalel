using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Notification;

namespace Models.Notification
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
public class NotificationConfigration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> modelBuilder)
    {
        modelBuilder.HasKey(notify => notify.Id);
        modelBuilder.Property(notification => notification.UserId)
          .IsRequired();

    }
}