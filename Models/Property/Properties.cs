using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Property.Enums;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class Properties
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int BuildingNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public bool CancelationOptions { get; set; }
        public PropertyStatus Status { get; set; } // int
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
                .WithOne(po => po.Properties)
                .HasForeignKey<Properties>(p => p.OwnerId);

            builder.HasMany(p => p.PropertyImages)
                .WithOne(pi => pi.Properties)
                .HasForeignKey(pi => pi.PropertyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
