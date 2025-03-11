using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeService
{
    public class ServiceQuaries
    {
        public int Id { get; set; }
        public int ServiceProviderId { get; set; }
        public int ClientId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime QuestionDate { get; set; }
        public DateTime AnswerDate { get; set; }
        public int CategoryServicesId { get; set; }
        public virtual CategoryServices CategoryServices { get; set; }
        public virtual ServiceProvider ServiceProvider { get; set; }
    }

    public class ServiceQuariesConfiguration : IEntityTypeConfiguration<ServiceQuaries>
    {
        public void Configure(EntityTypeBuilder<ServiceQuaries> builder)
        {
            // Primary Key
            builder.HasKey(sq => sq.Id);

            // Properties
            builder.Property(sq => sq.Question)
                .HasMaxLength(1000);

            builder.Property(sq => sq.Answer)
                .HasMaxLength(1000);

            // Relationships
            builder.HasOne(sq => sq.CategoryServices)
                .WithMany(cs => cs.Quaries)
                .HasForeignKey(sq => sq.CategoryServicesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sq => sq.ServiceProvider)
                .WithMany()
                .HasForeignKey(sq => sq.ServiceProviderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
