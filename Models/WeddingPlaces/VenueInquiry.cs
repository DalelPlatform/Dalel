using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;
using Models.WeddingPlaces.Enums;

namespace Models.WeddingPlaces
{
    public class VenueInquiry
    {
        public string Id { get; set; }
        public string VenueId { get; set; } // fk Venues.Id
        public string ClientId { get; set; } // fk clients.userId
        public InquiryStatus Status { get; set; }
        public DateTime SubmissionDate { get; set; }

        //Relations 
        //public Venues Venues { get; set; }
        public Client clients { get; set; }

    }

    public class VenueInquiryConfiguration : IEntityTypeConfiguration<VenueInquiry>
    {
        public void Configure(EntityTypeBuilder<VenueInquiry> builder)
        {
            builder.HasKey(vi => vi.Id);
            builder.Property(vi => vi.VenueId).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(vi => vi.ClientId).HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(vi => vi.Status).HasColumnType("NVARCHAR(50)").HasDefaultValue(InquiryStatus.Pending);
            builder.Property(vi => vi.SubmissionDate).HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);

           


        }
    }
}
