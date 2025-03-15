using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Agency;
using Models.Driver;
using Models.User;

namespace Models.Agency
{
    public class Agency_CustomerInquiry
    {
        public int Id { get; set; }
        public string Message { get; set; }

   public string Response { get; set; }
   public DateTime date { get; set; }
        public int AgencyId { get; set; }
        public TravelAgencyOwners AgencyOwners { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}

public class Agency_CustomerInquiryConfigration : IEntityTypeConfiguration<Agency_CustomerInquiry>
{
    public void Configure(EntityTypeBuilder<Agency_CustomerInquiry> modelBuilder)
    {

        modelBuilder.HasKey(CustomerInquiry => CustomerInquiry.Id);
        modelBuilder.HasOne(CustomerInquiry => CustomerInquiry.AgencyOwners)
        .WithMany(agency_Awn => agency_Awn.Inquiry)
        .HasForeignKey(CustomerInquiry => CustomerInquiry.AgencyId);

        modelBuilder.HasOne(c => c.Client)
       .WithMany(cus => cus.Agency_CustomerInquiries)
       .HasForeignKey(CustomerInquiry => CustomerInquiry.ClientId);

    }
}