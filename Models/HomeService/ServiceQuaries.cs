using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;

namespace Models.HomeService
{
    public class ServiceQuaries
    {
        public int Id { get; set; }
        public string ServiceProviderId { get; set; }
        public string ClientId { get; set; }
        public int ChatId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsSenderClient { get; set; }
        public int CategoryServicesId { get; set; }
        public virtual User.Client Client { get; set; }
        public virtual ServiceChat Chat { get; set; }
        public virtual CategoryServices CategoryServices { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }

    public class ServiceQuariesConfiguration : IEntityTypeConfiguration<ServiceQuaries>
    {
        public void Configure(EntityTypeBuilder<ServiceQuaries> builder)
        {
            // Primary Key
            builder.HasKey(sq => sq.Id);

            builder.Property(sq => sq.Comment)
                .HasMaxLength(1000);

            // Relationships
            builder.HasOne(sq => sq.CategoryServices)
                .WithMany(cs => cs.Quaries)
                .HasForeignKey(sq => sq.CategoryServicesId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sq => sq.ServiceProvider)
                .WithMany(i=>i.Quaries)
                .HasForeignKey(sq => sq.ServiceProviderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sc => sc.Client)
                .WithMany(sq => sq.ServiceQuaries)
                .HasForeignKey(sq => sq.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c=>c.Chat)
                .WithMany(q=>q.Quaries)
                .HasForeignKey(c=>c.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
