using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Agency
{
    public class AgencyCustomerInquiry
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public string Response { get; set; }
        public DateTime Date { get; set; }
        public string AgencyId { get; set; }
        public virtual TravelAgencyOwners AgencyOwners { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
    public class AgencyCustomerInquiryConfigration : IEntityTypeConfiguration<AgencyCustomerInquiry>
    {
        public void Configure(EntityTypeBuilder<AgencyCustomerInquiry> builder)
        {
            builder.HasOne(a => a.AgencyOwners).WithMany(q => q.Inquiries).HasForeignKey(a => a.AgencyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.Client).WithMany(q => q.Inquiries).HasForeignKey(a => a.ClientId);
            builder.Property(a => a.Date).HasDefaultValueSql("GetDate()");
        }
    }
}
