using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Property.Enums;
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
    }

    public class PropertiesConfigiruation : IEntityTypeConfiguration<Properties>
    {
        public void Configure(EntityTypeBuilder<Properties> builder)
        {

        }
    }
}
