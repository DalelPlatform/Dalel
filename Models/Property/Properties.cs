using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Enums;
using Models.User;

namespace Models.Property
{
    public class Properties
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Amenities { get; set; } 
        public int NumberOfRooms { get; set; }
        public float PricePerNight { get; set; }
        public int BuildingNo { get; set; }
        public int FloorNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public bool CancelationOptions { get; set; }
        public bool IsForRent { get; set; } 
        public VerificationStatus VerificationStatus { get; set; }
        public float CancelationCharges { get; set; }
        public DateTime ModificationDate { get; set; }
        public string OwnerId { get; set; } // fk PropertyOwners.userId
        public bool IsDeleted { get; set; }

        //relations
        public virtual PropertyOwner PropertyOwner { get; set; }
        public virtual ICollection<PropertyImages> PropertyImages { get; set; }
        public virtual ICollection<BookingProperties> BookingProperties { get; set; }
    }

    public class PropertiesConfigiruation : IEntityTypeConfiguration<Properties>
    {
        public void Configure(EntityTypeBuilder<Properties> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Address).HasMaxLength(500);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.Region).HasMaxLength(50);
            builder.Property(p => p.Street).HasMaxLength(50);
            builder.Property(p => p.PhoneNumber).HasMaxLength(50);

            //relations

            builder.HasOne(p => p.PropertyOwner)
                .WithMany(po => po.Properties)
                .HasForeignKey(p => p.OwnerId);

            builder.HasMany(p => p.PropertyImages)
                .WithOne(pi => pi.Properties)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
