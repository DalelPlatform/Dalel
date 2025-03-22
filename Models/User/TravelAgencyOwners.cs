using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Agency;

namespace Models.User
{
    public class TravelAgencyOwners
    {
        public string UserId { get; set; } // fk & pk
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection <TravelAgencies> TravelAgencies { get; set; }
        public virtual ICollection<AgencyCustomerInquiry> Inquiries { get; set; }
    }
    public class TravelAgencyOwnersConfigration : IEntityTypeConfiguration<TravelAgencyOwners>
    {
        public void Configure(EntityTypeBuilder<TravelAgencyOwners> builder)
        {
            builder.HasKey(a => a.UserId);
            builder
                .HasOne(a => a.AppUser)
                .WithOne(a =>a.TravelAgencyOwner)
                .HasForeignKey<TravelAgencyOwners>(a => a.UserId);
        }
    }
}
